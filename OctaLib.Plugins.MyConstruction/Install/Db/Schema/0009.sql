


create table app.Team (
	ProjectId int not null,
	WorkCategoryId int not null,
	ContractorId int not null,
	NoOfMen int not null,
	DateKey int not null,

	constraint PK_Team primary key (ProjectId, WorkCategoryId, ContractorId, DateKey),
	constraint FK_Team_Project foreign key (ProjectId) references Cofoundry.CustomEntity (CustomEntityId) on delete cascade on update no action,
	constraint FK_Team_WorkCategory foreign key (WorkCategoryId) references Cofoundry.CustomEntity (CustomEntityId) on delete no action on update no action,
	constraint FK_Team_Contractor foreign key (ContractorId) references Cofoundry.CustomEntity (CustomEntityId) on delete no action on update no action
)



