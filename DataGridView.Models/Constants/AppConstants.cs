namespace DataGridView.Models.Constants
{
    public static class AppConstants
    {
        public const int ProductNameMinLength = 3;
        public const int ProductNameMaxLength = 100;

        public const int QuantityMin = 0;
        public const int QuantityMax = 100;

        public const int MinQuantityMin = 0;
        public const int MinQuantityMax = 1000;

        public const decimal PriceMin = 0.01m;
        public const decimal PriceMax = 999999m;

        public const string FormTitle = "Реестр товаров";
        public const string FormEditTitle = "Редактирование товара";
        public const string FormAddTitle = "Добавление товара";
    }
}
