using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outputs.Constants;
using Outputs.Extensions;
using Outputs.Items;

namespace Outputs.Outputs
{
    public class ValidationResult : IEnumerable<Validation>
    {
        #region Contructors
        public ValidationResult()
        {
        }

        public ValidationResult(IEnumerable<Validation> collection)
        {
            Validations.AddRange(collection);
        }

        public ValidationResult(Exception ex)
            : this(ex != null ? ValidationFromException(ex) : new Validation[0])
        {
        }
        #endregion

        #region Privates
        private List<Validation> Validations { get; set; } = new List<Validation>();
        #endregion

        #region Private Methods
        private IEnumerator<Validation> Enumerate()
        {
            return Validations.GetEnumerator();
        }

        private static IEnumerable<Validation> ValidationFromException(Exception ex)
        {
            return new[] {new ValidationError(0, $"Unhandled Exception: {ex.ToLogString()}")};
        }
        #endregion

        #region Members
        public DateTime ErrorDate { get; set; }
        public List<DateTime> ErrorDateList { get; set; } = new List<DateTime>();
        public int Count => Validations.Count;
        public bool HasErrors => Errors.Length > 0;
        public bool HasWarnings => Warnings.Length > 0;
        public bool IsEmpty => Validations.Count == 0;

        private ValidationError[] Errors
        {
            get => Validations.OfType<ValidationError>().ToArray();
            set => Validations.AddRange(value);
        }

        private ValidationWarning[] Warnings
        {
            get => Validations.OfType<ValidationWarning>().ToArray();
            set => Validations.AddRange(value);
        }

        public string Extra { get; set; }

        public string Message
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var validation in Validations)
                    sb.AppendLine(validation.Message);

                return sb.ToString();
            }
        }

        public string TraceMessage
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var validation in Validations)
                    sb.AppendLine(validation.TraceMessage);

                return sb.ToString();
            }
        }
        #endregion

        #region Methods
        public static readonly ValidationResult Empty = new ValidationResult();

        public void Clear()
        {
            Validations.Clear();
        }

        public bool Contains(int code)
        {
            return Validations.FirstOrDefault(x => x.Code.Equals(code)) != null;
        }

        public bool ContainsOnly(int code)
        {
            var codes = Validations.Select(x => x.Code).Distinct();
            var enumerable = codes as int[] ?? codes.ToArray();
            return enumerable.Length == 1 && enumerable.First() == code;
        }

        public bool Contains(Validation val)
        {
            return Validations.Contains(val);
        }

        public ValidationResult AddValidation(Validation validation)
        {
            Validations.Add(validation);
            return this;
        }

        public ValidationResult AddError(string message)
        {
            Validations.Add(new ValidationError(ErrorCodes.UndefinedError, message));
            return this;
        }

        public ValidationResult AddError(int code, string message)
        {
            Validations.Add(new ValidationError(code, message));
            return this;
        }

        public ValidationResult AddWarning(string message)
        {
            Validations.Add(new ValidationWarning(0, message));
            return this;
        }

        public ValidationResult AddWarning(int code, string message)
        {
            Validations.Add(new ValidationWarning(code, message));
            return this;
        }

        public ValidationResult AddException(Exception ex)
        {
            AddError(ex.Message);
            return this;
        }

        public ValidationResult Add(ValidationResult validationResult)
        {
            Validations.AddRange(validationResult.Validations);
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var validation in Validations)
                sb.AppendLine(validation.ToString());

            return sb.ToString();
        }
        #endregion

        #region IEnumerable members
        public IEnumerator<Validation> GetEnumerator()
        {
            return Enumerate();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Enumerate();
        }
        #endregion
    }
}