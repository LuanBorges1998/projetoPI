create database projetoPI;

create table documento(
	id serial not null primary key,
	nome varchar,
	diretorio varchar
);

create table parceiro(
	id serial not null primary key,
	nome varchar
);

create table contrario(
	id serial not null primary key,
	nome varchar
);

create table cliente(
	id serial not null primary key,
	nome varchar
);

create table parceiro_documento(
	id_documento int not null references documento(id),
	id_parceiro int not null references parceiro(id),
	primary key(id_documento, id_parceiro)
);

create table contrario_documento(
	id_documento int not null references documento(id),
	id_contrario int not null references contrario(id),
	primary key(id_documento, id_contrario)
);

create table cliente_documento(
	id_documento int not null references documento(id),
	id_cliente int not null references cliente(id),
	primary key(id_documento, id_cliente)
);

create table perfil(
	id serial not null primary key,
	tipo varchar not null
);

create table usuario(
	id serial not null primary key,
	nome varchar,
	login varchar not null,
	senha varchar not null,
	id_perfil int references perfil(id) not null
);

create table advogado(
	id serial not null primary key,
	num_oab varchar,
	id_usuario int references usuario(id),
	id_socio int references advogado(id)
);

create table agendamento(
	id serial not null primary key,
	horario time,
	data_agendamento date,
	nome varchar,
	descricao varchar,
	id_usuario int not null references usuario(id) 
);

create table processo(
	id serial not null primary key,
	descricao varchar,
	id_cliente int not null references cliente(id),
	id_advogado int not null references advogado(id),
	id_contrario int not null references contrario(id)
);

create table etapa(
	id serial not null primary key,
	id_processo int not null references processo(id),
	valor_pago float 
);