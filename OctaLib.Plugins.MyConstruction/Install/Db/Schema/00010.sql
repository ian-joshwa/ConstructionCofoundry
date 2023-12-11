


create table app.Material (
	ProjectId int not null,
	StockId int not null,
	NewStock int,
	UsedStock int,
	Datekey int not null,

	constraint PK_Material primary key (ProjectId, StockId, Datekey),
	constraint FK_Material_Project foreign key (ProjectId) references Cofoundry.CustomEntity (CustomEntityId) on delete cascade on update no action,
	constraint FK_Material_Stock foreign key (StockId) references Cofoundry.CustomEntity (CustomEntityId) on delete no action on update no action
)



