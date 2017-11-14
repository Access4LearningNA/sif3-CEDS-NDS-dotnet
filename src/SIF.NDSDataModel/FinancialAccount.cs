namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinancialAccount", Schema = "ODS")]
    public partial class FinancialAccount
    {
        public int FinancialAccountId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [StringLength(30)]
        public string AccountNumber { get; set; }

        public int? RefFinancialAccountCategoryId { get; set; }

        public int? RefFinancialAccountFundClassificationId { get; set; }

        public int? RefFinancialAccountProgramCodeId { get; set; }

        public int? RefFinancialAccountBalanceSheetCodeId { get; set; }

        public int? RefFinancialExpenditureFunctionCodeId { get; set; }

        public int? RefFinancialExpenditureObjectCodeId { get; set; }

        [StringLength(30)]
        public string FinancialAccountNumber { get; set; }

        public decimal? FinancialExpenditureProjectReportingCode { get; set; }

        public int? RefFinancialExpenditureLevelOfInstructionCodeId { get; set; }

        public int? RefFinancialAccountRevenueCodeId { get; set; }
    }
}
