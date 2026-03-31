using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace DataGridView.WinForms.Extensions
{
    /// <summary>
    /// Методы расширения для DataBinding с валидацией
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Привязывает свойство контрола к свойству объекта с валидацией через ErrorProvider
        /// </summary>
        public static void AddBinding<TControl, TSource>(
            this TControl control,
            string controlProperty,
            TSource source,
            Expression<Func<TSource, object>> sourceProperty,
            ErrorProvider? errorProvider = null)
            where TControl : Control
            where TSource : class
        {
            var sourcePropertyName = GetMemberName(sourceProperty);

            control.DataBindings.Add(
                controlProperty,
                source,
                sourcePropertyName,
                formattingEnabled: false,
                DataSourceUpdateMode.OnPropertyChanged
            );

            if (errorProvider != null)
            {
                control.Validating += (_, e) =>
                {
                    var context = new ValidationContext(source);
                    var results = new List<ValidationResult>();
                    errorProvider.SetError(control, null);

                    if (!Validator.TryValidateObject(source, context, results, validateAllProperties: true))
                    {
                        foreach (var error in results.Where(x => x.MemberNames.Contains(sourcePropertyName)))
                        {
                            errorProvider.SetError(control, error.ErrorMessage);
                            e.Cancel = true;
                        }
                    }
                };
            }
        }

        /// <summary>
        /// Извлекает имя свойства из лямбда выражения
        /// </summary>
        private static string GetMemberName<T>(Expression<T> expression)
        {
            if (expression.Body is UnaryExpression unaryExpression)
            {
                var unExp = (MemberExpression)unaryExpression.Operand;
                return unExp.Member.Name;
            }

            var memExp = (MemberExpression)expression.Body;
            return memExp.Member.Name;
        }
    }
}
