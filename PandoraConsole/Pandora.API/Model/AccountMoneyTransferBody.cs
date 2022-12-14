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
    /// AccountMoneyTransferBody
    /// </summary>
    [DataContract]
        public partial class AccountMoneyTransferBody :  IEquatable<AccountMoneyTransferBody>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountMoneyTransferBody" /> class.
        /// </summary>
        /// <param name="amount">amount (required).</param>
        /// <param name="fromAccountNumber">fromAccountNumber (required).</param>
        /// <param name="info">info.</param>
        /// <param name="passport">passport (required).</param>
        /// <param name="receiver">receiver.</param>
        /// <param name="toAccountNumber">toAccountNumber.</param>
        public AccountMoneyTransferBody(double? amount = default(double?), string fromAccountNumber = default(string), string info = default(string), string passport = default(string), string receiver = default(string), string toAccountNumber = default(string))
        {
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new InvalidDataException("amount is a required property for AccountMoneyTransferBody and cannot be null");
            }
            else
            {
                this.Amount = amount;
            }
            // to ensure "fromAccountNumber" is required (not null)
            if (fromAccountNumber == null)
            {
                throw new InvalidDataException("fromAccountNumber is a required property for AccountMoneyTransferBody and cannot be null");
            }
            else
            {
                this.FromAccountNumber = fromAccountNumber;
            }
            // to ensure "passport" is required (not null)
            if (passport == null)
            {
                throw new InvalidDataException("passport is a required property for AccountMoneyTransferBody and cannot be null");
            }
            else
            {
                this.Passport = passport;
            }
            this.Info = info;
            this.Receiver = receiver;
            this.ToAccountNumber = toAccountNumber;
        }
        
        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue=false)]
        public double? Amount { get; set; }

        /// <summary>
        /// Gets or Sets FromAccountNumber
        /// </summary>
        [DataMember(Name="from_account_number", EmitDefaultValue=false)]
        public string FromAccountNumber { get; set; }

        /// <summary>
        /// Gets or Sets Info
        /// </summary>
        [DataMember(Name="info", EmitDefaultValue=false)]
        public string Info { get; set; }

        /// <summary>
        /// Gets or Sets Passport
        /// </summary>
        [DataMember(Name="passport", EmitDefaultValue=false)]
        public string Passport { get; set; }

        /// <summary>
        /// Gets or Sets Receiver
        /// </summary>
        [DataMember(Name="receiver", EmitDefaultValue=false)]
        public string Receiver { get; set; }

        /// <summary>
        /// Gets or Sets ToAccountNumber
        /// </summary>
        [DataMember(Name="to_account_number", EmitDefaultValue=false)]
        public string ToAccountNumber { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AccountMoneyTransferBody {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  FromAccountNumber: ").Append(FromAccountNumber).Append("\n");
            sb.Append("  Info: ").Append(Info).Append("\n");
            sb.Append("  Passport: ").Append(Passport).Append("\n");
            sb.Append("  Receiver: ").Append(Receiver).Append("\n");
            sb.Append("  ToAccountNumber: ").Append(ToAccountNumber).Append("\n");
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
            return this.Equals(input as AccountMoneyTransferBody);
        }

        /// <summary>
        /// Returns true if AccountMoneyTransferBody instances are equal
        /// </summary>
        /// <param name="input">Instance of AccountMoneyTransferBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountMoneyTransferBody input)
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
                    this.FromAccountNumber == input.FromAccountNumber ||
                    (this.FromAccountNumber != null &&
                    this.FromAccountNumber.Equals(input.FromAccountNumber))
                ) && 
                (
                    this.Info == input.Info ||
                    (this.Info != null &&
                    this.Info.Equals(input.Info))
                ) && 
                (
                    this.Passport == input.Passport ||
                    (this.Passport != null &&
                    this.Passport.Equals(input.Passport))
                ) && 
                (
                    this.Receiver == input.Receiver ||
                    (this.Receiver != null &&
                    this.Receiver.Equals(input.Receiver))
                ) && 
                (
                    this.ToAccountNumber == input.ToAccountNumber ||
                    (this.ToAccountNumber != null &&
                    this.ToAccountNumber.Equals(input.ToAccountNumber))
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
                if (this.FromAccountNumber != null)
                    hashCode = hashCode * 59 + this.FromAccountNumber.GetHashCode();
                if (this.Info != null)
                    hashCode = hashCode * 59 + this.Info.GetHashCode();
                if (this.Passport != null)
                    hashCode = hashCode * 59 + this.Passport.GetHashCode();
                if (this.Receiver != null)
                    hashCode = hashCode * 59 + this.Receiver.GetHashCode();
                if (this.ToAccountNumber != null)
                    hashCode = hashCode * 59 + this.ToAccountNumber.GetHashCode();
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
