namespace Kon.BillingBash;

public static class BillingBashDomainErrorCodes
{
    /* You can add your business exception error codes here, as constants */
    public const string CannotGenerateBillWithoutItemsException = "BillingBash:010001";
    public const string ItemIsAlreadyBoundToBill = "BillingBash:010002";
}
