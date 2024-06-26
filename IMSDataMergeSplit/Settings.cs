using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;

namespace IMSDataMergeSplit
{
    public class SQLSetting
    {
        public string Instance { get; set; }
        public string Port { get; set; }
        public string Catalog { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UseLogin { get; set; }
        public string ComputerName { get; set; }
        public string ImagePath { get; set; }
    }

    public class Setting : IValidatableObject
    {
        public string RecordTrackingPath { get; set; }
        public string CustomerName { get; set; }
        public bool UseDB { get; set; }
        public string DataPath { get; set; }
        public string ImagePath { get; set; }
        public SQLSetting SQLSource { get; set; }
        public SQLSetting SQLDestination { get; set; }

        [XmlIgnoreAttribute]
        public string FilePath { get; set; }

        public Setting()
        {
        }

        public string GenerateConnectionString(string catalog)
        {
            if (!String.IsNullOrWhiteSpace(this.SQLDestination.Port) && !this.SQLDestination.Port.Contains(","))
                this.SQLDestination.Port = String.Format(",{0}", this.SQLDestination.Port);

            var sqlConnectionString = new SqlConnectionStringBuilder
            {
                DataSource = String.Format(@"{0}\{1}{2}", this.SQLDestination.ComputerName, this.SQLDestination.Instance, this.SQLDestination.Port),
                IntegratedSecurity = true,
                InitialCatalog = catalog,
                UserID = this.SQLDestination.UserName ?? "",
                Password = this.SQLDestination.Password ?? ""
            };
            return sqlConnectionString.ToString();
        }

        public Setting(string customerName, string recordTrackingPath, SQLSetting destination, string dataPath, string imagePath)
        {
            CustomerName = customerName;
            RecordTrackingPath = recordTrackingPath;
            UseDB = false;
            DataPath = dataPath;
            ImagePath = imagePath;
            SQLDestination = destination;
        }
        public Setting(string customerName, string recordTrackingPath, SQLSetting destination, SQLSetting source)
        {
            CustomerName = customerName;
            RecordTrackingPath = recordTrackingPath;
            UseDB = true;
            SQLDestination = destination;
            SQLSource = source;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(CustomerName))
                yield return new ValidationResult("CustomerName cannot be blank");
            //if (string.IsNullOrWhiteSpace(RecordTrackingPath))
            //    yield return new ValidationResult("RecordTrackingPath cannot be blank");
            //else if (!Directory.Exists(RecordTrackingPath))
            //    yield return new ValidationResult("RecordTrackingPath path does not exist");

            if (string.IsNullOrWhiteSpace(SQLDestination.Catalog))
                yield return new ValidationResult("Destination Catalog cannot be blank");
            if (string.IsNullOrWhiteSpace(SQLDestination.ComputerName))
                yield return new ValidationResult("Destination ComputerName cannot be blank");
            if (string.IsNullOrWhiteSpace(SQLDestination.Instance))
                yield return new ValidationResult("Destination Instance cannot be blank");

            if (SQLDestination.UseLogin)
            {
                if (string.IsNullOrWhiteSpace(SQLDestination.UserName))
                    yield return new ValidationResult("Destination UserName cannot be blank");
                if (string.IsNullOrWhiteSpace(SQLDestination.Password))
                    yield return new ValidationResult("Destination Password cannot be blank");
            }

            if (UseDB)
            {
                if (string.IsNullOrWhiteSpace(SQLSource.Catalog))
                    yield return new ValidationResult("Source Catalog cannot be blank");
                //if (string.IsNullOrWhiteSpace(SQLSource.ComputerName))
                //    yield return new ValidationResult("Source ComputerName cannot be blank");
                //if (string.IsNullOrWhiteSpace(SQLSource.Instance))
                //    yield return new ValidationResult("Source Instance cannot be blank");

                //if (SQLDestination.UseLogin)
                //{
                //    if (string.IsNullOrWhiteSpace(SQLSource.UserName))
                //        yield return new ValidationResult("Source UserName cannot be blank");
                //    if (string.IsNullOrWhiteSpace(SQLSource.Password))
                //        yield return new ValidationResult("Source Password cannot be blank");
                //}
            }
            else
            {
                if (string.IsNullOrWhiteSpace(DataPath))
                    yield return new ValidationResult("Source DataPath cannot be blank");
                else if (!Directory.Exists(DataPath))
                    yield return new ValidationResult("Source DataPath path does not exist");

                if (string.IsNullOrWhiteSpace(ImagePath))
                    yield return new ValidationResult("Source ImagePath cannot be blank");
                else if (!Directory.Exists(ImagePath))
                    yield return new ValidationResult("Source ImagePath path does not exist");
            }
        }
    }
}
