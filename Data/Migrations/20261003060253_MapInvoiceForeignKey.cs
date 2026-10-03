using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelanceTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class MapInvoiceForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "invoiceNumber",
                table: "Invoices",
                newName: "InvoiceNumber");

            migrationBuilder.RenameColumn(
                name: "dueDate",
                table: "Invoices",
                newName: "DueDate");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Invoices",
                newName: "Amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoiceNumber",
                table: "Invoices",
                newName: "invoiceNumber");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "Invoices",
                newName: "dueDate");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Invoices",
                newName: "amount");
        }
    }
}
