using System.Xml.Serialization;
using Newtonsoft.Json;

namespace DeepStack.Entities
{
    public class CardinalMPIResponse
    {
		/// <summary>
		/// ThreeDSVersion (Required: Y)
		/// This field contains the 3DS version that was used to process the transaction.
		///
		/// Possible Values:
		///
		/// 1.0.2
		///
		/// 2.1.0
		///
		/// 2.2.0
		///
		/// NOTE: Required for Mastercard Identity Check transactions in Authorization
		/// </summary>
		[XmlElement, JsonProperty("ThreeDSVersion")]
		public string ThreeDSVersion { get; set; }

		/// <summary>
		/// Enrolled (Required: Y)
		/// Status of Authentication eligibility.
		///
		/// Possible Values:
		///
		/// Y - Yes, Bank is participating in 3-D Secure protocol and will return the ACSUrl
		///
		/// N - No, Bank is not participating in 3-D Secure protocol
		///
		/// U - Unavailable, The DS or ACS is not available for authentication at the time of the request
		///
		/// B - Bypass, Merchant authentication rule is triggered to bypass authentication in this use case
		///
		/// NOTE: If the Enrolled value is NOT Y, then the Consumer is NOT eligible for Authentication.
		/// </summary>
		[XmlElement, JsonProperty("Enrolled")]
		public string Enrolled { get; set; }

        /// <summary>
        /// ErrorNo (Required: Y)
        /// Application error number(s). A non-zero value represents the error encountered while attempting to process
        /// the message request.
        ///
        /// NOTE: Multiple error numbers are separated by a comma.
        /// </summary>
        [XmlElement, JsonProperty("ErrorNo")]
        public string ErrorNo { get; set; }

        [XmlIgnore, JsonIgnore] public bool ErrorNoSpecified => ErrorNo != null && ErrorNo != "0";

		/// <summary>
		/// ErrorDesc (Required: Y)
		/// Application error description for the associated error number(s).
		///
		/// NOTE: Multiple error descriptions are separated by a comma.
		/// </summary>
		[XmlElement, JsonProperty("ErrorDesc")]
		public string ErrorDesc { get; set; }

		/// <summary>
		/// EciFlag (Required: Y)
		/// Electronic Commerce Indicator (ECI). The ECI value is part of the 2 data elements that indicate the
		/// transaction was processed electronically. This should be passed on the authorization transaction to
		/// the Gateway/Processor.
		///
		/// Possible Values:
		///
		/// 02 or 05 - Fully Authenticated Transaction
		///
		/// 01 or 06 - Attempted Authentication Transaction
		///
		/// 00 or 07 - Non 3-D Secure Transaction
		///
		/// Mastercard - 02, 01, 00
		///
		/// VISA - 05, 06, 07
		///
		/// AMEX - 05, 06, 07
		///
		/// JCB - 05, 06, 07
		///
		/// DINERS CLUB - 05, 06, 07
		///
		/// Cartes Bancaires (CB) Visa - 05, 06, 07
		///
		/// Cartes Bancaires (CB) Mastercard -  02, 01, 00
		///
		/// ELO: 05, 06, 07
		///
		/// Union Pay International: 05, 06, 07
		/// </summary>
		[XmlElement, JsonProperty("EciFlag")]
		public string EciFlag { get; set; }

		/// <summary>
		/// OrderId (Required: Y)
		/// Centinel generated order identifier. Used to link multiple actions on a single order to a single identifier.
		/// Mod-10 compliant and unique BIN range to CardinalCommerce services.
		/// </summary>
		[XmlElement, JsonProperty("OrderId")]
		public long? OrderId { get; set; }

        [XmlIgnore, JsonIgnore] public bool OrderIdSpecified => OrderId != null;

		/// <summary>
		/// TransactionId (Required: Y)
		/// Centinel transaction identifier. This value identifies the transaction within the Centinel system.
		/// To complete the transaction, the value is required to be passed on the Authenticate message to link the
		/// Lookup and Authenticate message together.
		///
		/// NOTE: The TransactionId is the preferred identifier for linking the Lookup and Authenticate message.
		/// </summary>
		[XmlElement, JsonProperty("TransactionId")]
		public string TransactionId { get; set; }

		/// <summary>
		/// TransactionType (Required: Y)
		/// Identifies the transaction type used for processing.
		///
		/// Possible Values:
		///
		/// C - Credit Card/Debit Card Authentication
		/// </summary>
		[XmlElement, JsonProperty("TransactionType", NullValueHandling = NullValueHandling.Ignore)]
		public string TransactionType { get; set; }

		/// <summary>
		/// SignatureVerification (Required: C)
		/// Transaction Signature status identifier.
		///
		/// Possible Values:
		///
		/// Y - Indicates that the signature of the PARes has been validated successfully and the message contents can be trusted.
		///
		/// N - Indicates that the PARes could not be validated. This result could be for a variety of reasons;
		/// tampering, certificate expiration, etc., and the result should not be trusted.
		/// </summary>
		[XmlElement, JsonProperty("SignatureVerification", NullValueHandling = NullValueHandling.Ignore)]
		public string SignatureVerification { get; set; }

		/// <summary>
		/// CardBrand (Required: Y)
		/// Card brand that the transaction was processed for authentication.
		///
		/// Possible Values:
		///
		/// AMERICAN EXPRESS
		/// DISCOVER
		/// JCB
		/// MAESTRO
		/// MASTERCARD
		/// SOLO
		/// VISA
		/// UNKNOWN
		/// LASER
		/// ELECTRON
		/// DINERS CLUB
		/// ENROUTE
		/// ELO
		/// UPI
		/// </summary>
		[XmlElement, JsonProperty("CardBrand", NullValueHandling = NullValueHandling.Ignore)]
		public string CardBrand { get; set; }

		/// <summary>
		/// CardBin (Required: Y)
		/// Card bin represents the first six numbers of the CardNumber field passed in on the cmpi_lookup request.
		/// </summary>
		[XmlElement, JsonProperty("CardBin", NullValueHandling = NullValueHandling.Ignore)]
		public string CardBin { get; set; }

		/// <summary>
		/// DSTransactionId (Required: C)
		/// Unique transaction identifier assigned by the Directory Server (DS) to identify a single transaction.
		///
		/// NOTE: Required for Mastercard Identity Check transaction in Authorization - Only available in EMV 3DS (3DS 2.0) transactions
		/// </summary>
		[XmlElement, JsonProperty("DSTransactionId", NullValueHandling = NullValueHandling.Ignore)]
		public string DSTransactionId { get; set; }

		/// <summary>
		/// RawACSUrl (Required: C)
		/// The fully qualified URL to redirect the Consumer to complete the Consumer Authentication transaction.
		///
		/// NOTE: Available if Enrolled = Y
		/// </summary>
		[XmlElement, JsonProperty("RawACSUrl", NullValueHandling = NullValueHandling.Ignore)]
		public string RawACSUrl { get; set; }

		/// <summary>
		/// ACSUrl (Required: C)
		/// The fully qualified URL to redirect the Consumer to complete the Consumer Authentication transaction.
		///
		/// NOTE: Available if Enrolled = Y
		/// </summary>
		[XmlElement, JsonProperty("ACSUrl", NullValueHandling = NullValueHandling.Ignore)]
		public string ACSUrl { get; set; }

		/// <summary>
		/// StepUpUrl (Required: C)
		/// The fully qualified URL that the client uses to post the cardholder in order to complete the Consumer
		/// Authentication transaction for the Cardinal Cruise API integration.
		///
		/// NOTE: This is only for a Cardinal Cruise API Integration
		/// </summary>
		[XmlElement, JsonProperty("StepUpUrl", NullValueHandling = NullValueHandling.Ignore)]
		public string StepUpUrl { get; set; }

		/// <summary>
		/// Cavv (Required: C)
		/// Cardholder Authentication Verification Value (CAVV)
		///
		/// Authentication Verification Value (AVV)
		///
		/// Universal Cardholder Authentication Field (UCAF)
		///
		/// This value should be appended to the authorization message signifying that the transaction has been
		/// successfully authenticated. This value will be encoded according to the Merchant's configuration in either
		/// Base64 encoding or Hex encoding. A Base64 encoding Merchant configuration will produce values of 28 or 32
		/// characters A Hex encoding Merchant configuration will produce values of 40 or 48 characters. The value when
		/// decoded will either be 20 bytes for CAVV or 20 or 24 bytes if the value is AAV (Mastercard UCAF).
		/// </summary>
		[XmlElement, JsonProperty("Cavv", NullValueHandling = NullValueHandling.Ignore)]
		public string Cavv { get; set; }

		/// <summary>
		/// PAResStatus (Required: C)
		/// Transactions status result identifier.
		///
		/// Possible Values:
		///
		/// Y - Successful Authentication
		///
		/// N - Failed Authentication / Account Not Verified / Transaction Denied
		///
		/// U - Unable to Complete Authentication
		///
		/// A - Successful Attempts Transaction
		///
		/// C - Challenge Required for Authentication
		///
		/// R - Authentication Rejected (Merchant must not submit for authorization)
		///
		/// D - Challenge Required; Decoupled Authentication confirmed.
		///
		/// I - Informational Only; 3DS Requestor challenge preference acknowledged.
		///
		/// NOTE: Statuses of C and R only apply to Consumer Authentication 2.0.  Decoupled authentication is not supported at this time.
		/// </summary>
		[XmlElement, JsonProperty("PAResStatus", NullValueHandling = NullValueHandling.Ignore)]
		public string PAResStatus { get; set; }

		/// <summary>
		/// Payload (Required: C)
		/// The encoded payment request generated by Centinel.
		///
		/// NOTE: Available if Enrolled = Y
		/// </summary>
		[XmlElement, JsonProperty("Payload", NullValueHandling = NullValueHandling.Ignore)]
		public string Payload { get; set; }

		/// <summary>
		/// Xid (Required: C)
		/// Transaction identifier resulting from authentication processing.
		///
		/// NOTE: Gateway/Processor API specification may require this value to be appended to the authorization message.
		/// This value will be encoded according to the Merchant's configuration in either Base64 encoding or Hex
		/// encoding. A Base64 encoding Merchant configuration will produce values of 28 characters. A Hex encoding
		/// Merchant configuration will produce values of 40 characters.
		/// </summary>
		[XmlElement, JsonProperty("Xid", NullValueHandling = NullValueHandling.Ignore)]
		public string Xid { get; set; }

		/// <summary>
		/// CavvAlgorithm (Required: C)
		/// Indicates the algorithm used to generate the CAVV value.
		///
		/// Possible Values:
		///
		/// 2 - CVV with ATN
		///
		/// 3 - Mastercard SPA algorithm
		///
		/// NOTE: Only returned for MasterCard SecureCode transaction (3DS 1.0).
		/// </summary>
		[XmlElement, JsonProperty("CavvAlgorithm", NullValueHandling = NullValueHandling.Ignore)]
		public string CavvAlgorithm { get; set; }

		/// <summary>
		/// MerchantReferenceNumber (Required: O)
		/// Merchant specified data that is echoed back.
		///
		/// NOTE: This is the same value that was passed in on the cmpi_lookup request in the MerchantReferenceNumber field.
		/// </summary>
		[XmlElement, JsonProperty("MerchantReferenceNumber", NullValueHandling = NullValueHandling.Ignore)]
		public string MerchantReferenceNumber { get; set; }

		/// <summary>
		/// UCAFIndicator (Required: C)
		/// Universal Cardholder Authentication Field (UCAF) Indicator value provided by the issuer.
		///
		/// Possible Values:
		///
		/// 0 - Non-SecureCode transaction, bypassed by the Merchant
		///
		/// 1 - Merchant-Only SecureCode transaction
		///
		/// 2 - Fully authenticated SecureCode transaction
		///
		/// NOTE: This field is only returned for Mastercard SecureCode transactions (3DS 1.0)
		/// </summary>
		[XmlElement, JsonProperty("UCAFIndicator", NullValueHandling = NullValueHandling.Ignore)]
		public string UCAFIndicator { get; set; }

		/// <summary>
		/// DecoupledIndicator (Required: C)
		/// Indicates whether the ACS confirms utilisation of Decoupled Authentication and agrees to utilise
		/// Decoupled Authentication to authenticate the Cardholder.
		///
		/// Possible Values:
		///
		/// Y - Confirms Decoupled Authentication will be utilised
		///
		///
		///
		/// N - Decoupled Authentication will not be utilised
		///
		///
		///
		/// NOTE:
		///
		/// If 3DS Requestor Decoupled Request Indicator = N, a value of Y cannot be returned in the ACS Decoupled Confirmation Indicator.
		///
		/// If Transaction Status = D, a value of N is not valid.  Decoupled authentication is not supported at this time.
		/// </summary>
		[XmlElement, JsonProperty("DecoupledIndicator", NullValueHandling = NullValueHandling.Ignore)]
		public string DecoupledIndicator { get; set; }

		/// <summary>
		/// ReasonCode (Required: C)
		/// The error code indicating a problem with this transaction.
		/// </summary>
		[XmlElement, JsonProperty("ReasonCode", NullValueHandling = NullValueHandling.Ignore)]
		public string ReasonCode { get; set; }

		/// <summary>
		/// ReasonDesc (Required: C)
		/// Text and additional detail about the error for this transaction.
		///
		/// NOTE: This field concatenates the errorDescription and errorDetail from the authentication response message
		/// </summary>
		[XmlElement, JsonProperty("ReasonDesc", NullValueHandling = NullValueHandling.Ignore)]
		public string ReasonDesc { get; set; }

		/// <summary>
		/// Warning (Required: C)
		/// Text and additional detail about the error for this transaction. This field will concatenate all the fields
		/// from optional extensions that are contributing to the error.
		///
		/// Note: This is a soft error and will not stop the transaction. Although, merchants are recommended to take
		/// corrective action to overcome the Warning message.
		/// </summary>
		[XmlElement, JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Warning { get; set; }

		/// <summary>
		/// CardHolderInfo (Required: C)
		/// Text provided by the ACS/Issuer to Cardholder during a Frictionless transaction.
		///
		/// The Issuer can provide information to Cardholder. For example, “Additional authentication is needed for
		/// this transaction, please contact (Issuer Name) at xxx-xxx-xxxx.”.
		///
		/// The Issuing Bank can optionally support this value. The merchant is required to display this within their
		/// Checkout when present.
		///
		/// NOTE:  Supports 3RI Device Channel in version 2.2.0.  Decoupled authentication is not supported at this time.
		/// </summary>
		[XmlElement, JsonProperty("CardHolderInfo", NullValueHandling = NullValueHandling.Ignore)]
		public string CardHolderInfo { get; set; }

		/// <summary>
		/// ACSRenderingType (Required: C)
		/// Identifies the UI Type the ACS will use to complete the challenge.
		///
		/// NOTE: Only available for App transactions using the Cardinal Mobile SDK.
		/// </summary>
		[XmlElement, JsonProperty("ACSRenderingType", NullValueHandling = NullValueHandling.Ignore)]
		public string ACSRenderingType { get; set; }

		/// <summary>
		/// AuthenticationType (Required: C)
		/// Indicates the type of authentication that will be used to challenge the card holder.
		///
		/// Possible Values:
		///
		/// 01 - Static
		///
		/// 02 - Dynamic
		///
		/// 03 - OOB (Out of Band)
		///
		/// 04 - Decoupled
		///
		/// NOTE:  EMV® 3-D Secure version 2.1.0 supports values 01-03.  Version 2.2.0 supports values 01-04.
		/// Decoupled authentication is not supported at this time.
		/// </summary>
		[XmlElement, JsonProperty("AuthenticationType", NullValueHandling = NullValueHandling.Ignore)]
		public string AuthenticationType { get; set; }

		/// <summary>
		/// ChallengeRequired (Required: C)
		/// Indicates whether a challenge is required to complete authentication. For example, regional mandates.
		///
		/// Possible Values:
		///
		/// Y - Challenge Required
		///
		/// N - Challenge Not Required
		///
		/// NOTE:  Supports 3RI Device Channel in version 2.2.0.  Decoupled authentication is not supported at this time.
		/// </summary>
		[XmlElement, JsonProperty("ChallengeRequired", NullValueHandling = NullValueHandling.Ignore)]
		public string ChallengeRequired { get; set; }

		/// <summary>
		/// StatusReason (Required: C)
		/// Provides additional information as to why the PAResStatus has the specific value.
		///
		/// NOTE: Required for Payment (e.g. Authentication Indicator equals 01 on Lookup Request) transactions when
		/// PAResStatus is equal to N, U, or R in the Lookup Response.  Please refer to "EMV 3-D Secure Protocol and
		/// Core Functions Specification v2.2.0" for a list of Reason Codes.
		///
		/// See Possible Values
		/// </summary>
		[XmlElement, JsonProperty("StatusReason", NullValueHandling = NullValueHandling.Ignore)]
		public string StatusReason { get; set; }

		/// <summary>
		/// ACSTransactionId (Required: C)
		/// Unique transaction identifier assigned by the ACS to identify a single transaction.
		/// </summary>
		[XmlElement, JsonProperty("ACSTransactionId", NullValueHandling = NullValueHandling.Ignore)]
		public string ACSTransactionId { get; set; }

		/// <summary>
		/// ThreeDSServerTransactionId (Required: C)
		/// Unique transaction identifier assigned by the 3DS Server to identify a single transaction.
		/// </summary>
		[XmlElement, JsonProperty("ThreeDSServerTransactionId", NullValueHandling = NullValueHandling.Ignore)]
		public string ThreeDSServerTransactionId { get; set; }

		/// <summary>
		/// SDKFlowType (Required: C)
		/// Indicates the SDK Flow that was used as part of the transaction.
		/// </summary>
		[XmlElement, JsonProperty("SDKFlowType", NullValueHandling = NullValueHandling.Ignore)]
		public string SDKFlowType { get; set; }

		/// <summary>
		/// ACSReferenceNumber (Required: C)
		/// Unique identifier assigned by the EMVCo Secretariat upon Testing and Approval.
		/// </summary>
		[XmlElement, JsonProperty("ACSReferenceNumber", NullValueHandling = NullValueHandling.Ignore)]
		public string ACSReferenceNumber { get; set; }

		/// <summary>
		/// ACSOperatorId (Required: C)
		/// DS assigned ACS identifier.
		/// Each DS can provide a unique ID to each ACS
		/// on an individual basis.
		/// </summary>
		[XmlElement, JsonProperty("ACSOperatorId", NullValueHandling = NullValueHandling.Ignore)]
		public string ACSOperatorId { get; set; }

		/// <summary>
		/// ThirdPartyToken (Required: O)
		/// Third Party Token that is returned from the token provider after a card number is specified on the request.
		///
		/// NOTE: This field is returned if Tokenization is enabled in the Merchant profile setting AND the Merchant is
		/// using a third party token provider.
		/// </summary>
		[XmlElement, JsonProperty("ThirdPartyToken", NullValueHandling = NullValueHandling.Ignore)]
		public string ThirdPartyToken { get; set; }

		/// <summary>
		/// Token (Required: O)
		/// Centinel generated order identifier.
		///
		/// NOTE: This field is returned if Tokenization is enabled in the Merchant profile settings.
		/// </summary>
		[XmlElement, JsonProperty("Token", NullValueHandling = NullValueHandling.Ignore)]
		public string Token { get; set; }

		/// <summary>
		/// WhiteListStatus (Required: O)
		/// Enables the communication of trusted beneficiary status between the ACS, the DS and the 3DS Requestor.
		///
		/// Possible Values:
		///
		/// Y - 3DS Requestor is trustlisted by cardholder
		///
		/// N - 3DS Requestor is not trustlisted by cardholder
		///
		/// E - Not eligible as determined by issuer
		///
		/// P - Pending confirmation by cardholder
		///
		/// R - Cardholder rejected
		///
		/// U - Trustlist status unknown, unavailable, or does not apply
		///
		/// Note: This field may be returned for 2.1.0 if the MasterCard PSD2 extensions are passed and issuer supports them.
		/// </summary>
		[XmlElement, JsonProperty("WhiteListStatus", NullValueHandling = NullValueHandling.Ignore)]
		public string WhiteListStatus { get; set; }

		/// <summary>
		/// WhiteListStatusSource (Required: C)
		/// This data element will be populated by the system setting Whitelist Status.
		///
		/// Possible Values:
		///
		/// 01 - 3DS Server
		///
		/// 02 - DS
		///
		/// 03 - ACS
		/// </summary>
		[XmlElement, JsonProperty("WhiteListStatusSource", NullValueHandling = NullValueHandling.Ignore)]
		public string WhiteListStatusSource { get; set; }

		/// <summary>
		/// NetworkScore (Required: O)
		/// The global score calculated by the CB Scoring platform
		/// </summary>
		[XmlElement, JsonProperty("NetworkScore", NullValueHandling = NullValueHandling.Ignore)]
		public string NetworkScore { get; set; }

		/// <summary>
		/// ExemptionData (Required: C)
		/// Indicates the exemption applied by the ACS
		/// </summary>
		[XmlElement, JsonProperty("ExemptionData", NullValueHandling = NullValueHandling.Ignore)]
		public string ExemptionData { get; set; }

		/// <summary>
		/// AuthorizationPayload (Required: C)
		/// The Base64 encoded JSON Payload of CB specific Authorization Values returned in the Frictionless Flow.
		///
		/// Example File: AuthorizationPayload-JSON File
		/// </summary>
		[XmlElement, JsonProperty("AuthorizationPayload", NullValueHandling = NullValueHandling.Ignore)]
		public string AuthorizationPayload { get; set; }

		/// <summary>
		/// IvrEnabledMessage (Required: C)
		/// Flag to indicate if a valid IVR transaction was detected.
		/// </summary>
		[XmlElement, JsonProperty("IvrEnabledMessage", NullValueHandling = NullValueHandling.Ignore)]
		public bool IvrEnabledMessage { get; set; }

		/// <summary>
		/// IvrEncryptionKey (Required: C)
		/// Encryption key to be used in the event the ACS requires encryption of the credential field.
		/// </summary>
		[XmlElement, JsonProperty("IvrEncryptionKey", NullValueHandling = NullValueHandling.Ignore)]
		public string IvrEncryptionKey { get; set; }

		/// <summary>
		/// IvrEncryptionMandatory (Required: C)
		/// Flag to indicate if the ACS requires the credential to be encrypted.
		/// </summary>
		[XmlElement, JsonProperty("IvrEncryptionMandatory", NullValueHandling = NullValueHandling.Ignore)]
		public bool IvrEncryptionMandatory { get; set; }

		/// <summary>
		/// IvrEncryptionType (Required: C)
		/// An indicator from the ACS to inform the type of encryption that should be used in the event the ACS requires
		/// encryption of the credential field.
		/// </summary>
		[XmlElement, JsonProperty("IvrEncryptionType", NullValueHandling = NullValueHandling.Ignore)]
		public string IvrEncryptionType { get; set; }

		/// <summary>
		/// IvrLabel (Required: C)
		/// An ACS Provided label that can be presented to the Consumer. Recommended use with an application.
		/// </summary>
		[XmlElement, JsonProperty("IvrLabel", NullValueHandling = NullValueHandling.Ignore)]
		public string IvrLabel { get; set; }

		/// <summary>
		/// IvrPrompt (Required: C)
		/// An ACS provided string that can be presented to the Consumer. Recommended use with an application.
		/// </summary>
		[XmlElement, JsonProperty("IvrPrompt", NullValueHandling = NullValueHandling.Ignore)]
		public string IvrPrompt { get; set; }

		/// <summary>
		/// IvrStatusMessage (Required: C)
		/// An ACS provided message that can provide additional information or details.
		/// </summary>
		[XmlElement, JsonProperty("IvrStatusMessage", NullValueHandling = NullValueHandling.Ignore)]
		public string IvrStatusMessage { get; set; }

		/// <summary>
		/// IDCI_Score (Required: C)
		/// Risk Assessment from Mastercard
		/// </summary>
		[XmlElement, JsonProperty("IDCI_Score", NullValueHandling = NullValueHandling.Ignore)]
		public string IDCI_Score { get; set; }

		/// <summary>
		/// IDCI_Decision (Required: C)
		/// Decision on the Risk Assessment from Mastercard
		/// </summary>
		[XmlElement, JsonProperty("IDCI_Decision", NullValueHandling = NullValueHandling.Ignore)]
		public string IDCI_Decision { get; set; }

		/// <summary>
		/// IDCI_ReasonCode1 (Required: C)
		/// ReasonCode from Mastercard
		/// </summary>
		[XmlElement, JsonProperty("IDCI_ReasonCode1", NullValueHandling = NullValueHandling.Ignore)]
		public string IDCI_ReasonCode1 { get; set; }

		/// <summary>
		/// IDCI_ReasonCode2 (Required: C)
		/// ReasonCode from Mastercard
		/// </summary>
		[XmlElement, JsonProperty("IDCI_ReasonCode2", NullValueHandling = NullValueHandling.Ignore)]
		public string IDCI_ReasonCode2 { get; set; }


    }
}