namespace Kon.Accounting;

public static class AccountingDomainErrorCodes
{
    /* You can add your business exception error codes here, as constants */
    public const string CannotGenerateBillWithoutItemsException = "Accounting:010001";
    public const string ItemIsAlreadyBoundToBill = "Accounting:010002";
}
