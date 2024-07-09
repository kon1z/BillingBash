namespace Kon.AccountingService;

public static class AccountingServiceDomainErrorCodes
{
	public const string CannotGenerateBillWithoutItemsException = "Accounting:010001";
	public const string ItemIsAlreadyBoundToBill = "Accounting:010002";
}
