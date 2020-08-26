using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Library.Entity
{
    public static class Messages
    {

        public static string RequestForbidden { get { return "Fobidden"; } }

        public static string InvalidCredentials { get { return "Invalid Credentials"; } }

        public static string InvalidRequest { get { return "Invalid Request Body. Please check body parameter"; } }

        public static string InvalidEmail { get { return "Invalid Email Combination"; } }

        public static string InvalidPassword { get { return "Invalid Password Combination"; } }

        //////////////////////////////////////
        ///

        public static string MapLimitError { get { return "You have reached your limit of maps. Please delete an existing map or Upgrade Your Account to proceed."; } }

        public static string DatasetLimitError { get { return "You have reached your limit of datasets. Please delete an existing dataset or Upgrade Your Account to proceed."; } }

        public static string ObjectLimitHighestPlanError { get { return "You have reached your limit of {0}. Please delete an existing {1} or Contact Us to get a custom limit to proceed."; } }

        public static string DatasetSizeLimitError { get { return "Your plan only allows datasets to have {0} rows. You have reached the size limit for this dataset. Please Upgrade Your Account to add more rows to this dataset."; } }

        public static string GeocodeLimitError { get { return "You have reached the limit of locations you can add in a day. Please Upgrade Your Account to add more rows to this dataset."; } }

        public static string AddDatasetSizeLimitError { get { return "Your account is limited to {1} rows per dataset. This dataset contains {0} rows. Please reduce the number of rows in your dataset or Upgrade Your Account to proceed."; } }

        public static string AddDatasetSizeLimitHighestPlanError { get { return "Your account is limited to {1} rows per dataset. This dataset contains {0} rows. Please reduce the number of rows in your dataset or Contact Us to get a custom limit to proceed."; } }
        public static string AddDatasetGeocodeLimitError { get { return "This dataset contains {0} rows, and you only have {1} more locations you can process today. Please reduce the number of rows in your dataset or Upgrade Your Account to proceed."; } }

        public static string AddDatasetGeocodeLimitHighestPlanError { get { return "This dataset contains {0} rows, and you only have {1} more locations you can process today. Please reduce the number of rows in your dataset or Contact Us to get a custom limit to proceed."; } }

        public static string DropPinSizeLimitError { get { return "Your account is limited to {1} pin drop per layer. This layer contains {0} pins. Please Upgrade Your Account to proceed."; } }

        public static string DropPinSizeLimitHighestPlanError { get { return "Your account is limited to {1} pin drop per layer. This layer contains {0} pins. Please Contact Us to get a custom limit to proceed."; } }
        public static string DropPinGeocodeLimitError { get { return "You have reached your limit to drop pin today. Please Upgrade Your Account to proceed."; } }

        public static string DropPinGeocodeLimitHighestPlanError { get { return "You have reached your limit to drop pin today. Please Contact Us to get a custom limit to proceed."; } }



        public static string AccountLicenseLimitError { get { return "You have reached maximum limit of users on your account. Please upgrade your account to add more users."; } }
        public static string AccountLicenseLimitErrorForAdminstator { get { return "You have reached maximum limit of users on your account. Please contact your account owner to upgrade your account for adding more users."; } }

        public static string AccountMemberExists { get { return "{0} is a registered user. Please add user with a different e-mail address."; } }
        public static string AccountOwnerConstraint { get { return "Can't add another account owner."; } }
        public static string AddPermissionDenied { get { return "User don't have permission to add {0}."; } }
        public static string BillingAdminConstraint { get { return "An account can add a maximum of two Billing Admins."; } }
        public static string DatasetDuplicateName { get { return "You already have a dataset named {0}. Please provide a new name in your request."; } }
        public static string ViewDuplicateName { get { return "You already have a view named {0}. Please provide a new name in your request."; } }

        public static string DatasetDuplicateNameConstraint { get { return "Dataset Name already exist. Please try a new name.{0}"; } }
        public static string DatasetInProcess { get { return "This dataset already exists and is currently being processed. You may {0} this dataset once the processing is completed. Please try again in a few minutes."; } }
        public static string DatasetProcessing { get { return "This dataset is currently being processed. You may {0} once the processing is completed. Please try again in a few minutes."; } }
        public static string ObjectToUpdateNotFound { get { return "This {0} being edited may have been removed from the map. Please refresh your map and try again."; } }
        public static string DeletePermissionDenied { get { return "User don't have permission to delete this {0}."; } }
        public static string EditPermissionDenied { get { return "User doesn't have permission to edit/copy this {0}."; } }
        public static string EmailNotVerified { get { return "User must confirm their email address to activate their account."; } }
        public static string GetPermissionDenied { get { return "User doesn't have permission to lookup {0}."; } }
        public static string InvalidEmailFormat { get { return "Email address is not valid."; } }
        public static string InvalidEmailPassword { get { return "The email and password you entered did not match our records."; } }
        public static string InvalidPasswordFormat { get { return "Your password should have minimum of 8 characters with at least 1 letter and 1 number or special character."; } }
        public static string InvalidUrlFormat { get { return "Invalid Url."; } }
        public static string InvalidPostRequest { get { return "Invalid Post request. To edit {0} use [PUT] verb."; } }
        public static string InvalidPutRequest { get { return "Invalid Put request. To add {0} use [POST] verb."; } }
        public static string InvalidPaymentOption { get { return "Your account doesn't have a valid payment option. Please update your payment information to continue."; } }
        public static string InvalidCard { get { return "Please provide valid credit card details."; } }
        public static string InternalServerError { get { return "Internal Server Error. Please contact support if you encounter this error continuously."; } }
        public static string InvalidPaymentMode { get { return "This plan cannot be in automatic payment mode. Please change the payment mode as manual and try again."; } }
        public static string LoginSlotNotAvailable { get { return "Cannot login at this time. All available login slots are occupied. Please try again later."; } }
        public static string MissingAddressHeader { get { return "Invalid request body. Dataset headers is a required field and must contain a header related to address."; } }
        public static string MissingApiKey { get { return "You did not provide an API key. You need to provide your API key in the Authorization header."; } }
        public static string MissingDatasetRecord { get { return "Invalid request body. Dataset records is a required field and must contain atleast one record to process request."; } }
        public static string MissingRecordValues { get { return "Invalid request body. Record values is a required field and must contain a values related to record."; } }
        public static string MissingRequiredField { get { return "Invalid request body. Missing required field: {0}."; } }
        public static string NotFound { get { return "The requested resource is not found."; } }
        public static string ObjectLimitError { get { return "You have reached your limit of {0}."; } }
        public static string ObjectNotFound { get { return "Invalid request body. Unable to find a {0} matching the provided identifer."; } }
        public static string ObjectPaylodNotFound { get { return "Invalid request body. No {0} object found in the request."; } }
        public static string ApiLimitError { get { return "You have reached your limit of web api request."; } } //
        public static string ExcelAddinLimitError { get { return "You have reached installation limit. Please uninstall it from one computer and try again."; } }

        public static string ExcelAddinInvalidLicense { get { return "Your license in not valid. Please uninstall it and try again."; } }
        public static string RegisterUserDataError { get { return "Email address and/or Name is not found."; } }

        public static string RegisterIfEmailExists { get { return "This email is already registered."; } }
        public static string ColumnLimitError { get { return "We currently support 256 headers in a single dataset. You have reached your limit of headers."; } }

        public static string NewUserAdded { get { return "{0} was successfully added to your account. An email was sent to the new user with login instructions."; } }

        public static string PlanUpgradeError { get { return "Upgrade your plan to {0} Plan."; } }

        public static string ExportError { get { return "You must have plus membership to export {0}."; } }

        public static string RecaptchaValidationFailed { get { return "Recaptcha not verified, please try again."; } }

        public static string TrialSuccessMessage { get { return "Congratulations! A {0}-day, Enterprise trial has been activated on your account!"; } }

        public static string TrialNotificationMessage { get { return "Your account has been upgraded to a Free Enterprise Plan Trial which will expire on {0}."; } }

        public static string InvalidTrialPromoCode { get { return "The code you entered is not valid. Please enter a valid promo code and try again."; } }

        public static string DatasetNotInLibrary { get { return "In order to proceed, you will need to save this dataset to your Dataset Library."; } }

        public static string DatasetNotHaveAddress { get { return "Dataset don't have address headers. So you cann't add it on map."; } }

        public static string SubscriptionInvoiceExist { get { return "Invoice for this subscription period is already created."; } }

        public static string InvalidFileExtension { get { return "Your file type is not valid. Only PNG, JPG, JPEG, GIF, and BMP files can be uploaded."; } }
        public static string FileSizExceed { get { return "Your file size cannot exceed {0} MB."; } }



        public static string SharePermissionDeniedForLockedAccount { get { return "Your account has been configured to only allow sharing with other users on your same account."; } }

        public static string EmbedPermissionDenied { get { return "You don't have permission to embed your {0}. Please contact your Account Owner."; } }
        public static string CvcCheckNotDone { get { return "Your card's security code is incorrect."; } }
        public static string AddUserDeniedForLockedAccount { get { return "Your account has been configured to only allow email addresses from the {0}"; } }
    }


}
