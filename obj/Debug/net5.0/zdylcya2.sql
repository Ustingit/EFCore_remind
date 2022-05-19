CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

ALTER TABLE "Users" ADD "Position" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220516174120_Add position for suer', '5.0.17');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "Users" ADD "IsMarried" INTEGER NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220516174546_addIsMarry', '5.0.17');

COMMIT;

