/* 
 * Pandoran global apis
 *
 * The set of APIs for all services at Pandora
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// ApiBuyBody
    /// </summary>
    [DataContract]
        public partial class ApiBuyBody :  IEquatable<ApiBuyBody>, IValidatableObject
    {
        /// <summary>
        /// Defines PaymentType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum PaymentTypeEnum
        {
            /// <summary>
            /// Enum Cash for value: Cash
            /// </summary>
            [EnumMember(Value = "Cash")]
            Cash = 1,
            /// <summary>
            /// Enum BankAccount for value: BankAccount
            /// </summary>
            [EnumMember(Value = "BankAccount")]
            BankAccount = 2        }
        /// <summary>
        /// Gets or Sets PaymentType
        /// </summary>
        [DataMember(Name="payment_type", EmitDefaultValue=false)]
        public PaymentTypeEnum PaymentType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiBuyBody" /> class.
        /// </summary>
        /// <param name="amount">amount (required).</param>
        /// <param name="bankAccount">bankAccount.</param>
        /// <param name="customerSsn">customerSsn (required).</param>
        /// <param name="description">description.</param>
        /// <param name="orderDate">orderDate.</param>
        /// <param name="passport">passport (required).</param>
        /// <param name="paymentType">paymentType (required).</param>
        /// <param name="product">product (required).</param>
        public ApiBuyBody(double? amount = default(double?), string bankAccount = default(string), string customerSsn = default(string), string description = default(string), DateTime? orderDate = default(DateTime?), string passport = default(string), PaymentTypeEnum paymentType = default(PaymentTypeEnum), string product = default(string))
        {
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new InvalidDataException("amount is a required property for ApiBuyBody and cannot be null");
            }
            else
            {
                this.Amount = amount;
            }
            // to ensure "customerSsn" is required (not null)
            if (customerSsn == null)
            {
                throw new InvalidDataException("customerSsn is a required property for ApiBuyBody and cannot be null");
            }
            else
            {
                this.CustomerSsn = customerSsn;
            }
            // to ensure "passport" is required (not null)
            if (passport == null)
            {
                throw new InvalidDataException("passport is a required property for ApiBuyBody and cannot be null");
            }
            else
            {
                this.Passport = passport;
            }
            // to ensure "paymentType" is required (not null)
            if (paymentType == null)
            {
                throw new InvalidDataException("paymentType is a required property for ApiBuyBody and cannot be null");
            }
            else
            {
                this.PaymentType = paymentType;
            }
            // to ensure "product" is required (not null)
            if (product == null)
            {
                throw new InvalidDataException("product is a required property for ApiBuyBody and cannot be null");
            }
            else
            {
                this.Product = product;
            }
            this.BankAccount = bankAccount;
            this.Description = description;
            this.OrderDate = orderDate;
        }
        
        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue=false)]
        public double? Amount { get; set; }

        /// <summary>
        /// Gets or Sets BankAccount
        /// </summary>
        [DataMember(Name="bank_account", EmitDefaultValue=false)]
        public string BankAccount { get; set; }

        /// <summary>
        /// Gets or Sets CustomerSsn
        /// </summary>
        [DataMember(Name="customer_ssn", EmitDefaultValue=false)]
        public string CustomerSsn { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets OrderDate
        /// </summary>
        [DataMember(Name="order_date", EmitDefaultValue=false)]
        [JsonConverter(typeof(SwaggerDateConverter))]
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// Gets or Sets Passport
        /// </summary>
        [DataMember(Name="passport", EmitDefaultValue=false)]
        public string Passport { get; set; }


        /// <summary>
        /// Gets or Sets Product
        /// </summary>
        [DataMember(Name="product", EmitDefaultValue=false)]
        public string Product { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiBuyBody {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  BankAccount: ").Append(BankAccount).Append("\n");
            sb.Append("  CustomerSsn: ").Append(CustomerSsn).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  OrderDate: ").Append(OrderDate).Append("\n");
            sb.Append("  Passport: ").Append(Passport).Append("\n");
            sb.Append("  PaymentType: ").Append(PaymentType).Append("\n");
            sb.Append("  Product: ").Append(Product).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ApiBuyBody);
        }

        /// <summary>
        /// Returns true if ApiBuyBody instances are equal
        /// </summary>
        /// <param name="input">Instance of ApiBuyBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiBuyBody input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
                ) && 
                (
                    this.BankAccount == input.BankAccount ||
                    (this.BankAccount != null &&
                    this.BankAccount.Equals(input.BankAccount))
                ) && 
                (
                    this.CustomerSsn == input.CustomerSsn ||
                    (this.CustomerSsn != null &&
                    this.CustomerSsn.Equals(input.CustomerSsn))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.OrderDate == input.OrderDate ||
                    (this.OrderDate != null &&
                    this.OrderDate.Equals(input.OrderDate))
                ) && 
                (
                    this.Passport == input.Passport ||
                    (this.Passport != null &&
                    this.Passport.Equals(input.Passport))
                ) && 
                (
                    this.PaymentType == input.PaymentType ||
                    (this.PaymentType != null &&
                    this.PaymentType.Equals(input.PaymentType))
                ) && 
                (
                    this.Product == input.Product ||
                    (this.Product != null &&
                    this.Product.Equals(input.Product))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Amount != null)
                    hashCode = hashCode * 59 + this.Amount.GetHashCode();
                if (this.BankAccount != null)
                    hashCode = hashCode * 59 + this.BankAccount.GetHashCode();
                if (this.CustomerSsn != null)
                    hashCode = hashCode * 59 + this.CustomerSsn.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.OrderDate != null)
                    hashCode = hashCode * 59 + this.OrderDate.GetHashCode();
                if (this.Passport != null)
                    hashCode = hashCode * 59 + this.Passport.GetHashCode();
                if (this.PaymentType != null)
                    hashCode = hashCode * 59 + this.PaymentType.GetHashCode();
                if (this.Product != null)
                    hashCode = hashCode * 59 + this.Product.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
