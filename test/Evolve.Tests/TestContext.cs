﻿using System;
using System.IO;
using System.Reflection;
using Evolve.Tests.Infrastructure;
using Xunit;

namespace Evolve.Tests
{
    public static class TestContext
    {
        public static string ProjectFolder => Path.GetDirectoryName(typeof(TestContext).GetTypeInfo().Assembly.Location);
        public static bool AppVeyor => Environment.GetEnvironmentVariable("APPVEYOR") == "True";
        public static bool AzureDevOps => Environment.GetEnvironmentVariable("TF_BUILD") == "True";
        public static bool Local => !AppVeyor && !AzureDevOps;
        public static string ResourcesFolder => Path.Combine(ProjectFolder, "Resources");
        public static string CrLfScriptPath => Path.Combine(ResourcesFolder, "LF_CRLF/V2_3_1__Migration_description.sql");
        public static string LfScriptPath => Path.Combine(ResourcesFolder, "LF_CRLF/V2_3_2__Migration_description_lf.sql");
        public static string Scripts1 => Path.Combine(ResourcesFolder, "Scripts_1");
        public static string Scripts2 => Path.Combine(ResourcesFolder, "Scripts_2");

        public static class Cassandra
        {
            public static string ResourcesFolder => Path.Combine(ProjectFolder, "Integration/Cassandra/Resources");
            public static string SqlScriptsFolder => Path.Combine(ResourcesFolder, "Cql_Scripts");
            public static string MigrationFolder => Path.Combine(SqlScriptsFolder, "Migration");
            public static string ChecksumMismatchFolder => Path.Combine(SqlScriptsFolder, "Checksum_mismatch");
            public static string EmptyMigrationScriptPath => Path.Combine(ResourcesFolder, "V1_3_2__Migration_description.cql");
        }

        public static class MySQL
        {
            public static string ResourcesFolder => Path.Combine(ProjectFolder, "Integration/MySQL/Resources");
            public static string SqlScriptsFolder => Path.Combine(ResourcesFolder, "Sql_Scripts");
            public static string MigrationFolder => Path.Combine(SqlScriptsFolder, "Migration");
            public static string ChecksumMismatchFolder => Path.Combine(SqlScriptsFolder, "Checksum_mismatch");
            public static string EmptyMigrationScriptPath => Path.Combine(ResourcesFolder, "V1_3_2__Migration_description.sql");
        }

        public static class PostgreSQL
        {
            public static string ResourcesFolder => Path.Combine(ProjectFolder, "Integration/PostgreSQL/Resources");
            public static string SqlScriptsFolder => Path.Combine(ResourcesFolder, "Sql_Scripts");
            public static string MigrationFolder => Path.Combine(SqlScriptsFolder, "Migration");
            public static string Migration11Folder => Path.Combine(SqlScriptsFolder, "Migration11"); // PostgreSQL 11
            public static string ChecksumMismatchFolder => Path.Combine(SqlScriptsFolder, "Checksum_mismatch");
            public static string OutOfOrderFolder => Path.Combine(SqlScriptsFolder, "OutOfOrder");
            public static string EmptyMigrationScriptPath => Path.Combine(ResourcesFolder, "V1_3_2__Migration_description.sql");
        }

        public static class SQLite
        {
            public static string ResourcesFolder => Path.Combine(ProjectFolder, "Integration/SQLite/Resources");
            public static string SqlScriptsFolder => Path.Combine(ResourcesFolder, "Sql_Scripts");
            public static string MigrationFolder => Path.Combine(SqlScriptsFolder, "Migration");
            public static string ChecksumMismatchFolder => Path.Combine(SqlScriptsFolder, "Checksum_mismatch");
            public static string ChinookScriptPath => Path.Combine(SqlScriptsFolder, "Chinook_Sqlite.sql");
            public static string ChinookScript => File.ReadAllText(ChinookScriptPath);
        }

        public static class SqlServer
        {
            public static string ResourcesFolder => Path.Combine(ProjectFolder, "Integration/SQLServer/Resources");
            public static string SqlScriptsFolder => Path.Combine(ResourcesFolder, "Sql_Scripts");
            public static string MigrationFolder => Path.Combine(SqlScriptsFolder, "Migration");
            public static string ChecksumMismatchFolder => Path.Combine(SqlScriptsFolder, "Checksum_mismatch");
            public static string EmptyMigrationScriptPath => Path.Combine(ResourcesFolder, "V1_3_2__Migration_description.sql");
        }
    }

    [CollectionDefinition("Cassandra collection")]
    public class CassandraCollection : IClassFixture<CassandraFixture> { }

    [CollectionDefinition("MySQL collection")]
    public class MySQLCollection : IClassFixture<MySQLFixture> { }

    [CollectionDefinition("PostgreSql collection")]
    public class PostgreSqlCollection : IClassFixture<PostgreSqlFixture> { }

    [CollectionDefinition("SQLServer collection")]
    public class SQLServerCollection : IClassFixture<SQLServerFixture> { }
}