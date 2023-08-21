create table "__EFMigrationsHistory"
(
    "MigrationId"    varchar(150) not null
        constraint "PK___EFMigrationsHistory"
            primary key,
    "ProductVersion" varchar(32)  not null
);

alter table "__EFMigrationsHistory"
    owner to postgres;

create table "AspNetRoles"
(
    "Id"               bigint generated by default as identity
        constraint "PK_AspNetRoles"
            primary key,
    "Name"             varchar(256),
    "NormalizedName"   varchar(256),
    "ConcurrencyStamp" text
);

alter table "AspNetRoles"
    owner to postgres;

create unique index "RoleNameIndex"
    on "AspNetRoles" ("NormalizedName");

create table "AspNetUsers"
(
    "Id"                     bigint generated by default as identity
        constraint "PK_AspNetUsers"
            primary key,
    "Name"                   text                     not null,
    "Surname"                text                     not null,
    "Patronymic"             text,
    "RefreshToken"           text,
    "RefreshTokenExpiryTime" timestamp with time zone not null,
    "UserName"               varchar(256),
    "NormalizedUserName"     varchar(256),
    "Email"                  varchar(256),
    "NormalizedEmail"        varchar(256),
    "EmailConfirmed"         boolean                  not null,
    "PasswordHash"           text,
    "SecurityStamp"          text,
    "ConcurrencyStamp"       text,
    "PhoneNumber"            text,
    "PhoneNumberConfirmed"   boolean                  not null,
    "TwoFactorEnabled"       boolean                  not null,
    "LockoutEnd"             timestamp with time zone,
    "LockoutEnabled"         boolean                  not null,
    "AccessFailedCount"      integer                  not null
);

alter table "AspNetUsers"
    owner to postgres;

create index "EmailIndex"
    on "AspNetUsers" ("NormalizedEmail");

create unique index "UserNameIndex"
    on "AspNetUsers" ("NormalizedUserName");

create table "County"
(
    "Id"   bigint generated by default as identity
        constraint "PK_County"
            primary key,
    "Name" text not null
);

alter table "County"
    owner to postgres;

create table "Speciality"
(
    "Id"   bigint generated by default as identity
        constraint "PK_Speciality"
            primary key,
    "Name" text not null
);

alter table "Speciality"
    owner to postgres;

create table "Type"
(
    "Id"   bigint generated by default as identity
        constraint "PK_Type"
            primary key,
    "Name" text not null
);

alter table "Type"
    owner to postgres;

create table "AspNetRoleClaims"
(
    "Id"         integer generated by default as identity
        constraint "PK_AspNetRoleClaims"
            primary key,
    "RoleId"     bigint not null
        constraint "FK_AspNetRoleClaims_AspNetRoles_RoleId"
            references "AspNetRoles"
            on delete cascade,
    "ClaimType"  text,
    "ClaimValue" text
);

alter table "AspNetRoleClaims"
    owner to postgres;

create index "IX_AspNetRoleClaims_RoleId"
    on "AspNetRoleClaims" ("RoleId");

create table "AspNetUserClaims"
(
    "Id"         integer generated by default as identity
        constraint "PK_AspNetUserClaims"
            primary key,
    "UserId"     bigint not null
        constraint "FK_AspNetUserClaims_AspNetUsers_UserId"
            references "AspNetUsers"
            on delete cascade,
    "ClaimType"  text,
    "ClaimValue" text
);

alter table "AspNetUserClaims"
    owner to postgres;

create index "IX_AspNetUserClaims_UserId"
    on "AspNetUserClaims" ("UserId");

create table "AspNetUserLogins"
(
    "LoginProvider"       text   not null,
    "ProviderKey"         text   not null,
    "ProviderDisplayName" text,
    "UserId"              bigint not null
        constraint "FK_AspNetUserLogins_AspNetUsers_UserId"
            references "AspNetUsers"
            on delete cascade,
    constraint "PK_AspNetUserLogins"
        primary key ("LoginProvider", "ProviderKey")
);

alter table "AspNetUserLogins"
    owner to postgres;

create index "IX_AspNetUserLogins_UserId"
    on "AspNetUserLogins" ("UserId");

create table "AspNetUserRoles"
(
    "UserId" bigint not null
        constraint "FK_AspNetUserRoles_AspNetUsers_UserId"
            references "AspNetUsers"
            on delete cascade,
    "RoleId" bigint not null
        constraint "FK_AspNetUserRoles_AspNetRoles_RoleId"
            references "AspNetRoles"
            on delete cascade,
    constraint "PK_AspNetUserRoles"
        primary key ("UserId", "RoleId")
);

alter table "AspNetUserRoles"
    owner to postgres;

create index "IX_AspNetUserRoles_RoleId"
    on "AspNetUserRoles" ("RoleId");

create table "AspNetUserTokens"
(
    "UserId"        bigint not null
        constraint "FK_AspNetUserTokens_AspNetUsers_UserId"
            references "AspNetUsers"
            on delete cascade,
    "LoginProvider" text   not null,
    "Name"          text   not null,
    "Value"         text,
    constraint "PK_AspNetUserTokens"
        primary key ("UserId", "LoginProvider", "Name")
);

alter table "AspNetUserTokens"
    owner to postgres;

create table "Region"
(
    "Id"       bigint generated by default as identity
        constraint "PK_Region"
            primary key,
    "CountyId" bigint not null
        constraint "FK_Region_County_CountyId"
            references "County"
            on delete cascade,
    "Name"     text   not null
);

alter table "Region"
    owner to postgres;

create index "IX_Region_CountyId"
    on "Region" ("CountyId");

create table "City"
(
    "Id"       bigint generated by default as identity
        constraint "PK_City"
            primary key,
    "RegionId" bigint not null
        constraint "FK_City_Region_RegionId"
            references "Region"
            on delete cascade,
    "Name"     text   not null
);

alter table "City"
    owner to postgres;

create index "IX_City_RegionId"
    on "City" ("RegionId");

create table "Hospital"
(
    "Id"          bigint generated by default as identity
        constraint "PK_Hospital"
            primary key,
    "Description" text     not null,
    "Address"     text     not null,
    "StartedTime" time     not null,
    "EndTime"     time     not null,
    "Contacts"    text     not null,
    "Rating"      smallint not null,
    "Email"       text     not null,
    "CityId"      bigint   not null
        constraint "FK_Hospital_City_CityId"
            references "City"
            on delete cascade,
    "Name"        text     not null
);

alter table "Hospital"
    owner to postgres;

create index "IX_Hospital_CityId"
    on "Hospital" ("CityId");

create table "Doctor"
(
    "Id"           bigint generated by default as identity
        constraint "PK_Doctor"
            primary key,
    "Surname"      text   not null,
    "Patronymic"   text   not null,
    "HospitalId"   bigint not null
        constraint "FK_Doctor_Hospital_HospitalId"
            references "Hospital"
            on delete cascade,
    "SpecialityId" bigint not null
        constraint "FK_Doctor_Speciality_SpecialityId"
            references "Speciality"
            on delete cascade,
    "Name"         text   not null
);

alter table "Doctor"
    owner to postgres;

create index "IX_Doctor_HospitalId"
    on "Doctor" ("HospitalId");

create index "IX_Doctor_SpecialityId"
    on "Doctor" ("SpecialityId");

create table "Appointment"
(
    "Id"        bigint generated by default as identity
        constraint "PK_Appointment"
            primary key,
    "Time"      time                     not null,
    "Date"      timestamp with time zone not null,
    "TypeId"    bigint                   not null
        constraint "FK_Appointment_Type_TypeId"
            references "Type"
            on delete cascade,
    "PatientId" bigint                   not null
        constraint "FK_Appointment_AspNetUsers_PatientId"
            references "AspNetUsers"
            on delete cascade,
    "DoctorId"  bigint                   not null
        constraint "FK_Appointment_Doctor_DoctorId"
            references "Doctor"
            on delete cascade,
    "IsOpen"    boolean                  not null,
    "Name"      text                     not null
);

alter table "Appointment"
    owner to postgres;

create index "IX_Appointment_DoctorId"
    on "Appointment" ("DoctorId");

create index "IX_Appointment_PatientId"
    on "Appointment" ("PatientId");

create index "IX_Appointment_TypeId"
    on "Appointment" ("TypeId");

INSERT INTO public."County"(
	"Name")
	VALUES ('Дальневосточный'),
		   ('Приволжский'),
		   ('Северо-Западный'),
		   ('Северо-Кавказский'),
		   ('Сибирский'),
		   ('Уральский'),
		   ('Центральный'),
		   ('Южный');

INSERT INTO public."Region"(
	"CountyId", "Name")
	VALUES (1, 'Амурская область'),
	       (1, 'Республика Бурятия'),
	       (1, 'Еврейская автономная область'),
	       (1, 'Забайкальский край'),
	       (1, 'Камчатский край'),
	       (1, 'Магаданская область'),
	       (1, 'Приморский край'),
	       (1, 'Республика Саха (Якутия)'),
	       (1, 'Сахалинская область'),
	       (1, 'Хабаровский край'),
	       (1, 'Чукотский автономный округ'),
	       (2, 'Республика Башкортостан'),
	       (2, 'Кировская область'),
	       (2, 'Республика Марий Эл'),
	       (2, 'Республика Мордовия'),
	       (2, 'Нижегородская область'),
	       (2, 'Оренбургская область'),
	       (2, 'Пензенская область'),
	       (2, 'Пермский край'),
	       (2, 'Самарская область'),
	       (2, 'Саратовская область'),
	       (2, 'Республика Татарстан'),
	       (2, 'Удмуртская Республика'),
	       (2, 'Ульяновская область'),
	       (2, 'Чувашская Республика'),
	       (3, 'Архангельская область'),
	       (3, 'Вологодская область'),
	       (3, 'Калининградская область'),
	       (3, 'Республика Карелия'),
	       (3, 'Республика Коми'),
	       (3, 'Ленинградская область'),
	       (3, 'Мурманская область'),
	       (3, 'Ненецкий автономный округ'),
	       (3, 'Новгородская область'),
	       (3, 'Псковская область'),
	       (3, 'Санкт-Петербург'),
	       (4, 'Республика Дагестан'),
	       (4, 'Республика Ингушетия'),
	       (4, 'Кабардино-Балкарская Республика'),
	       (4, 'Карачаево-Черкесская Республика'),
	       (4, 'Республика Северная Осетия — Алания'),
	       (4, 'Ставропольский край'),
	       (4, 'Чеченская Республика'),
	       (5, 'Республика Алтай'),
		   (5, 'Алтайский край'),
		   (5, 'Иркутская область'),
		   (5, 'Кемеровская область — Кузбасс'),
		   (5, 'Красноярский край'),
		   (5, 'Новосибирская область'),
		   (5, 'Омская область'),
		   (5, 'Томская область'),
		   (5, 'Республика Тыва'),
		   (5, 'Республика Хакасия'),
		   (6, 'Курганская область'),
		   (6, 'Свердловская область'),
		   (6, 'Тюменская область'),
		   (6, 'Ханты-Манскийский автономный округ-Югра'),
		   (6, 'Челябинская область'),
		   (6, 'Ямало-Немецкий автономный округ'),
		   (7, 'Белгородская область'),
		   (7, 'Брянская область'),
		   (7, 'Владимирская область'),
		   (7, 'Воронежская область'),
		   (7, 'Ивановская область'),
		   (7, 'Калужская область'),
		   (7, 'Костромская область'),
		   (7, 'Курская область'),
		   (7, 'Липецкая область'),
		   (7, 'Москва'),
		   (7, 'Московская область'),
		   (7, 'Орловская область'),
		   (7, 'Рязанская область'),
		   (7, 'Смоленская область'),
		   (7, 'Тамбовская область'),
		   (7, 'Тверская область'),
		   (7, 'Тульская область'),
		   (7, 'Ярославская область'),
		   (8, 'Республика Адыгея'),
		   (8, 'Астраханская область'),
		   (8, 'Волгоградская область'),
		   (8, 'Республика Калмыкия'),
		   (8, 'Краснодарский край'),
		   (8, 'Ростовская область'),
		   (8, 'Республика Крым'),
		   (8, 'Севастополь');

INSERT INTO public."City"(
	"RegionId", "Name")
	VALUES (66, 'Буй'),
	       (66, 'Волгореченск'),
	       (66, 'Галич'),
	       (66, 'Кологрив'),
	       (66, 'Кострома'),
	       (66, 'Макарьев'),
	       (66, 'Мантурово'),
	       (66, 'Нерехта'),
	       (66, 'Нея'),
	       (66, 'Солигалич'),
	       (66, 'Чухлома'),
	       (66, 'Шарья'),
               (1, 'Белогорск'),
	       (1, 'Благовещенск'),
	       (1, 'Завитинск'),
	       (1, 'Зея'),
	       (1, 'Райчихинск'),
	       (1, 'Свободный'),
	       (1, 'Сковородино'),
	       (1, 'Тында'),
	       (1, 'Циолковский'),
	       (1, 'Шимановск');;

INSERT INTO public."Hospital"(
	"Description", "Address", "StartedTime", "EndTime", "Contacts", "Rating", "Email", "CityId", "Name")
	VALUES ('Описание', 'улица Пушкина, дом колатушкина 3', '06:00:00', '23:00:00', 'регистратура - 1111111111', '5', 'pergor@mail.ru', 5, 'первая городская больница');

INSERT INTO public."AspNetRoles"(
	"Name", "NormalizedName")
	VALUES ('Patient', 'PATIENT'),
	       ('Doctor','DOCTOR'),
               ('Admin','ADMIN');