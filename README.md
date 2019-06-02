view->other window->concole dispetcher
PM> add-migration update020619
No migrations configuration type was found in the assembly 'CrmUserInterface'. (In Visual Studio you can use the Enable-Migrations command from Package Manager Console to add a migrations configuration).

PM> add-migration update020619

Scaffolding migration 'update020619'.
The Designer Code for this migration file includes a snapshot of your current Code First model. This snapshot is used to calculate the changes to your model when you scaffold the next migration. If you make additional changes to your model that you want to include in this migration, then you can re-scaffold it by running 'Add-Migration update020619' again.

PM> update-database

Specify the '-Verbose' flag to view the SQL statements being applied to the target database.
Applying explicit migrations: [201906020731483_update020619].
Applying explicit migration: 201906020731483_update020619.
Caution: Changing any part of an object name could break scripts and stored procedures.
Running Seed method.
PM> 
