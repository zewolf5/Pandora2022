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
    /// EmployeeCollectSalaryBody
    /// </summary>
    [DataContract]
        public partial class EmployeeCollectSalaryBody :  IEquatable<EmployeeCollectSalaryBody>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeCollectSalaryBody" /> class.
        /// </summary>
        /// <param name="pandoranSsn">pandoranSsn (required).</param>
        /// <param name="passport">passport (required).</param>
        public EmployeeCollectSalaryBody(string pandoranSsn = default(string), string passport = default(string))
        {
            // to ensure "pandoranSsn" is required (not null)
            if (pandoranSsn == null)
            {
                throw new InvalidDataException("pandoranSsn is a required property for EmployeeCollectSalaryBody and cannot be null");
            }
            else
            {
                this.PandoranSsn = pandoranSsn;
            }
            // to ensure "passport" is required (not null)
            if (passport == null)
            {
                throw new InvalidDataException("passport is a required property for EmployeeCollectSalaryBody and cannot be null");
            }
            else
            {
                this.Passport = passport;
            }
        }
        
        /// <summary>
        /// Gets or Sets PandoranSsn
        /// </summary>
        [DataMember(Name="pandoran_ssn", EmitDefaultValue=false)]
        public string PandoranSsn { get; set; }

        /// <summary>
        /// Gets or Sets Passport
        /// </summary>
        [DataMember(Name="passport", EmitDefaultValue=false)]
        public string Passport { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EmployeeCollectSalaryBody {\n");
            sb.Append("  PandoranSsn: ").Append(PandoranSsn).Append("\n");
            sb.Append("  Passport: ").Append(Passport).Append("\n");
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
            return this.Equals(input as EmployeeCollectSalaryBody);
        }

        /// <summary>
        /// Returns true if EmployeeCollectSalaryBody instances are equal
        /// </summary>
        /// <param name="input">Instance of EmployeeCollectSalaryBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EmployeeCollectSalaryBody input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.PandoranSsn == input.PandoranSsn ||
                    (this.PandoranSsn != null &&
                    this.PandoranSsn.Equals(input.PandoranSsn))
                ) && 
                (
                    this.Passport == input.Passport ||
                    (this.Passport != null &&
                    this.Passport.Equals(input.Passport))
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
                if (this.PandoranSsn != null)
                    hashCode = hashCode * 59 + this.PandoranSsn.GetHashCode();
                if (this.Passport != null)
                    hashCode = hashCode * 59 + this.Passport.GetHashCode();
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
