namespace WebApiDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Specialty = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicalTreatments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Notes = c.String(nullable: false),
                        Diseases = c.String(nullable: false),
                        PatientId = c.Long(nullable: false),
                        DoctorId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MedicalTreatment_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalTreatments", t => t.MedicalTreatment_Id)
                .Index(t => t.MedicalTreatment_Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        Job = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalTreatments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Medicines", "MedicalTreatment_Id", "dbo.MedicalTreatments");
            DropForeignKey("dbo.MedicalTreatments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Medicines", new[] { "MedicalTreatment_Id" });
            DropIndex("dbo.MedicalTreatments", new[] { "DoctorId" });
            DropIndex("dbo.MedicalTreatments", new[] { "PatientId" });
            DropTable("dbo.Patients");
            DropTable("dbo.Medicines");
            DropTable("dbo.MedicalTreatments");
            DropTable("dbo.Doctors");
        }
    }
}
