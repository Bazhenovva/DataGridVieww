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
                    var property = source.GetType().GetProperty(sourcePropertyName);

                    if (property == null)
                    {
                        return;
                    }

                    var value = property.GetValue(source);

                    var context = new ValidationContext(source)
                    {
                        MemberName = sourcePropertyName
                    };

                    var results = new List<ValidationResult>();

                    errorProvider.SetError(control, null);

                    if (!Validator.TryValidateProperty(value, context, results))
                    {
                        foreach (var error in results)
                        {
                            errorProvider.SetError(control, error.ErrorMessage);
                        }

                        e.Cancel = true;
                    }
                };
            }
        }

        /// <summary>
        /// Извлекает имя свойства из лямбда-выражения
        /// </summary>
        private static string GetMemberName<T>(Expression<Func<T, object>> expression)
        {
            if (expression.Body is UnaryExpression unary)
            {
                return ((MemberExpression)unary.Operand).Member.Name;
            }

            return ((MemberExpression)expression.Body).Member.Name;
        }
    }
}
