namespace System;
public static class ErrorCodes
{
    public const string ERR1001 = "Please provide a valid category.";
    public const string ERR1002 = "Please provide a valid category ID.";
    public const string ERR1003 = "Sorry, we could not find the category you are looking for.";
    public const string ERR1004 = "Sorry, we could not find the category you are trying to remove.";
    public const string ERR1005 = "Sorry, we could not find the category you are trying to update.";
    public const string ERR1006 = "Please provide a product to add.";
    public const string ERR1007 = "The product ID is invalid. Please provide a valid ID.";
    public const string ERR1008 = "Please provide at least one category ID.";
    public const string ERR1009 = "Please provide a product to update.";
    public const string ERR1010 = "Please provide a valid product ID.";
    public const string ERR1011 = "The product you are looking for does not exist. Please try another ID.";
    public const string ERR1012 = "Please provide a valid product with a stock greater than zero.";
    public const string ERR1013 = "Unable to retrieve the categories. Please try again later.";
    public const string ERR1014 = "Unable to update the product stock. Please try again later.";
    public const string ERR1015 = "The product stock is insufficient. Please reduce the quantity or try another product.";
}
