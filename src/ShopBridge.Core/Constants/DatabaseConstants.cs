namespace System;
public static class DatabaseConstants
{
    #region names
    public const string DefaultDbContextName = "ShopBridgeContext";
    public const string ProductsCategoriesName = "ProductsCategories";
    public const string ProductIdName = "ProductId";
    public const string CategoryIdName = "CategoryId";
    #endregion

    #region column types
    public const string DatetimeColumnTypeName = "datetime";
    public const string GetDateSqlFunction = "GETDATE()";
    #endregion

    #region values
    public const int ZeroValue = 0;
    #endregion

    #region constraints
    public const string CKProductStockName = "CK_Product_Stock";
    public const string CKProductPriceName = "CK_Product_Price";
    public const string CKProductStock = "Stock >= 0";
    public const string CKProductPrice = "Price >= 0";
    #endregion

    #region lengths
    public const int DefaultLargeStringMaxLength = 500;
    public const int DefaultMediumStringMaxLength = 250;
    #endregion
}
