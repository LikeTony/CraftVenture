#Banco de dados feito por Antônio dono deste perfil

DROP DATABASE if exists bd_venture;

create database IF NOT EXISTS BD_Venture;

use BD_Venture;

set FOREIGN_KEY_CHECKS = 0;

create table usuario(
id int auto_increment,
nome varchar(50) not null unique,
email varchar(50) not null unique,
senha varchar(20) not null,
primary key(id)
);

CREATE TABLE cliente(
id INT AUTO_INCREMENT UNIQUE,
nome VARCHAR(50) NOT NULL,
email VARCHAR(50) NOT NULL UNIQUE,
telefone varchar(15) NOT NULL,
cep VARCHAR(10) NOT NULL,
rua VARCHAR(100) NOT NULL,
bairro VARCHAR(50) NOT NULL,
numero INT NOT NULL,
cidade varchar(50),
estado VARCHAR(8) NOT NULL,
complemento VARCHAR(100),
PRIMARY KEY(id)
);

create table venda(
id int auto_increment unique,
nomeCliente varchar(50) not null,
formaPagamento varchar(20) not null,
formaEntrega varchar(30) not null,
valorTotal decimal(10, 2) not null,
anotacao varchar(100),
dataEntrega date not null,
dataVenda date not null,
codigoCliente int not null,
primary key(id),
foreign key (codigoCliente) references cliente(id)
on update cascade
on delete cascade
);

create table produto(
id int auto_increment unique,
nome varchar(50) unique not null,
valor decimal(10, 2) not null,
tipo varchar(50) not null,
quantidade int not null,
foto longblob,
primary key(id)
);

create table vende(
id int auto_increment unique,
quantidade int not null,
idVenda int not null,
idProduto int not null,
primary key(id),
foreign key (idVenda) references venda(id)
on update cascade
on delete cascade,
foreign key (idProduto) references produto(id)
on update cascade
on delete cascade
);

create table tipoMaterial(
id int auto_increment unique,
nome varchar(50) not null,
primary key(id)
);

create table material(
id int auto_increment unique,
nome varchar(50) unique not null,
valor decimal(10,2) not null,
foto longblob,
idTipoMaterial int not null,
quantidade int,
primary key(id),
foreign key (idTipoMaterial) references tipoMaterial(id)
on update cascade
on delete cascade
);

create table MaterialProduto(
id int auto_increment unique,
idMaterial int not null,
idProduto int not null,
quantidade int,
primary key(id),
foreign key (idMaterial) references material(id)
on update cascade
on delete cascade,
foreign key (idProduto) references produto(id)
on update cascade
on delete cascade
);

create table papel(
idTipoMaterial int not null,
tipo varchar(20) not null,
gramatura char(3) not null,
cor varchar(10) not null,
tamanho char(2) not null,
primary key(idTipoMaterial),
foreign key (idTipoMaterial) references tipoMaterial(id)
on update cascade
on delete cascade
);

create table fita(
idTipoMaterial int not null,
tipo varchar(20) not null,
numero tinyint not null,
metragem decimal(20,2) not null,
marca varchar(15) not null,
numeroCor char(3) not null,
primary key(idTipoMaterial),
foreign key (idTipoMaterial) references tipoMaterial(id)
on update cascade
on delete cascade
);

create table perola(
idTipoMaterial int not null,
cor varchar(20) not null,
tamanho decimal(20,2) not null,
primary key(idTipoMaterial),
foreign key (idTipoMaterial) references tipoMaterial(id)
on update cascade
on delete cascade
);

create table tecido(
idTipoMaterial int not null,
tipo varchar(25) not null,
metragemAltura double not null,
metragemComprimento double not null,
tipoEstampa varchar(20) not null,
primary key(idTipoMaterial),
foreign key (idTipoMaterial) references tipoMaterial(id)
on update cascade
on delete cascade
);

create table renda(
idTipoMaterial int not null,
tamanho varchar(3),
metragem decimal(20,2),
primary key(idTipoMaterial),
foreign key (idTipoMaterial) references tipoMaterial(id)
on update cascade
on delete cascade
);

create table acetato(
idTipoMaterial int not null,
espessura decimal(20,2) not null,
metragemAltura double not null,
metragemComprimento double not null,
foto longblob,
primary key(idTipoMaterial),
foreign key (idTipoMaterial) references tipoMaterial(id)
on update cascade
on delete cascade
);

create table canudo(
idTipoMaterial int not null,
cor varchar(10) not null,
quantidade smallint not null,
primary key(idTipoMaterial),
foreign key (idTipoMaterial) references tipoMaterial(id)
on update cascade
on delete cascade
);

#PAPEL

INSERT INTO tipoMaterial(nome) VALUES('Papel');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Papel Pólen Branco A4 144', 1.99, LAST_INSERT_ID(), 100);
insert into papel() values (LAST_INSERT_ID(),'Pólen', '144', 'Branco', 'A4');

INSERT INTO tipoMaterial(nome) VALUES('Papel');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Papel Fosco Branco A4 180', 1.99, LAST_INSERT_ID(), 100);
insert into papel() values (LAST_INSERT_ID(),'Fosco', '180', 'Branco', 'A4');

INSERT INTO tipoMaterial(nome) VALUES('Papel');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Papel Colorplus Branco A5 108', 2.99, LAST_INSERT_ID(), 100);
insert into papel() values (LAST_INSERT_ID(),'Colorplus', '108', 'Branco', 'A5');

INSERT INTO tipoMaterial(nome) VALUES('Papel');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Papel Fotográfico Branco A3 90', 3.99, LAST_INSERT_ID(), 100);
insert into papel() values (LAST_INSERT_ID(),'Fotográfico', '90', 'Branco', 'A3');

INSERT INTO tipoMaterial(nome) VALUES('Papel');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Papel Fosco Branco A6 75', 1.50, LAST_INSERT_ID(), 100);
insert into papel() values (LAST_INSERT_ID(),'Fosco', '75', 'Branco', 'A6');


SELECT papel.idtipomaterial, tipo, material.nome, material.valor FROM papel 
INNER JOIN material ON papel.idtipomaterial = material.idtipomaterial
;

#fita

INSERT INTO tipoMaterial(nome) VALUES('Fita');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Fita Voil N° 1 N° Cor 2 B', 29.99, LAST_INSERT_ID(), 20);
insert into fita values (LAST_INSERT_ID(),'Voil', '1', '8', 'b', '2');

INSERT INTO tipoMaterial(nome) VALUES('Fita');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Fita Cetim N° 3 N° Cor 2 C', 29.99, LAST_INSERT_ID(), 20);
insert into fita values (LAST_INSERT_ID(),'Cetim', '3', '10', 'C', '2');

INSERT INTO tipoMaterial(nome) VALUES('Fita');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Fita Gorgurão N° 5 N° Cor 4 A', 29.99, LAST_INSERT_ID(), 20);
insert into fita values (LAST_INSERT_ID(),'Gorgurão', '5', '8', 'A', '4');

INSERT INTO tipoMaterial(nome) VALUES('Fita');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Fita Voil N° 2 N° Cor 7 A', 29.99, LAST_INSERT_ID(), 20);
insert into fita values (LAST_INSERT_ID(),'Voil', '6', '8', 'A', '7');

INSERT INTO tipoMaterial(nome) VALUES('Fita');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Fita Cetim N° 1 N° Cor 4 D', 29.99, LAST_INSERT_ID(), 20);
insert into fita values (LAST_INSERT_ID(),'Cetim', '1', '8', 'D', '4');


#Pérola

INSERT INTO tipoMaterial(nome) VALUES('Pérola');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Pérola Branco 12cm', 129.99, LAST_INSERT_ID(), 10);
insert into perola values (LAST_INSERT_ID(),'Branco', '12');

INSERT INTO tipoMaterial(nome) VALUES('Pérola');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Pérola Azul 12cm', 129.99, LAST_INSERT_ID(), 10);
insert into perola values (LAST_INSERT_ID(),'Azul', '12');

INSERT INTO tipoMaterial(nome) VALUES('Pérola');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Pérola Amarelo 10cm', 129.99, LAST_INSERT_ID(), 10);
insert into perola values (LAST_INSERT_ID(),'Amarelo', '10');

INSERT INTO tipoMaterial(nome) VALUES('Pérola');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Pérola Verde 12cm', 129.99, LAST_INSERT_ID(), 10);
insert into perola values (LAST_INSERT_ID(),'Verde', '12');

INSERT INTO tipoMaterial(nome) VALUES('Pérola');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Pérola Branco 5cm', 129.99, LAST_INSERT_ID(), 10);
insert into perola values (LAST_INSERT_ID(),'Branco', '5');


#Tecido

INSERT INTO tipoMaterial(nome) VALUES('Tecido');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Tecido Tule Estampado 4 cm', 33.99, LAST_INSERT_ID(), 15);
insert into tecido values (LAST_INSERT_ID(),'Tule', '5', '3', 'Estampado');

INSERT INTO tipoMaterial(nome) VALUES('Tecido');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Tecido Atoalhado Estampado 4 cm', 25.99, LAST_INSERT_ID(), 15);
insert into tecido values (LAST_INSERT_ID(),'Atoalhado', '2', '2', 'Liso');

INSERT INTO tipoMaterial(nome) VALUES('Tecido');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Tecido Tricoline Liso 9 cm', 49.99, LAST_INSERT_ID(), 15);
insert into tecido values (LAST_INSERT_ID(),'Tricoline', '3', '3', 'Liso');

INSERT INTO tipoMaterial(nome) VALUES('Tecido');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Tecido Feltro Estampado 6 cm', 32.99, LAST_INSERT_ID(), 15);
insert into tecido values (LAST_INSERT_ID(),'Feltro', '2', '3', 'Estampado');

INSERT INTO tipoMaterial(nome) VALUES('Tecido');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Tecido Fralda Liso 4 cm', 56.99, LAST_INSERT_ID(), 15);
insert into tecido values (LAST_INSERT_ID(),'Fralda', '2', '2', 'Liso');

#Renda

INSERT INTO tipoMaterial(nome) VALUES('Renda');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Renda N 16 m', 2.49, LAST_INSERT_ID(), 300);
insert into renda values (LAST_INSERT_ID(),'N', '16.0');

INSERT INTO tipoMaterial(nome) VALUES('Renda');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Renda P 14 m', 5.49, LAST_INSERT_ID(), 300);
insert into renda values (LAST_INSERT_ID(),'P', '14.0');

INSERT INTO tipoMaterial(nome) VALUES('Renda');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Renda G 18 m', 2.49, LAST_INSERT_ID(), 300);
insert into renda values (LAST_INSERT_ID(),'G', '18.0');

INSERT INTO tipoMaterial(nome) VALUES('Renda');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Renda N 4 m', 3.99, LAST_INSERT_ID(), 300);
insert into renda values (LAST_INSERT_ID(),'N', '4.0');

INSERT INTO tipoMaterial(nome) VALUES('Renda');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Renda G 20 m', 4.49, LAST_INSERT_ID(), 300);
insert into renda values (LAST_INSERT_ID(),'G', '20.0');

#Acetato

INSERT INTO tipoMaterial(nome) VALUES('Acetato');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Acetato 122 Micra 5 X 3', 12.99, LAST_INSERT_ID(), 30);
insert into acetato (idTipoMaterial, espessura, metragemAltura, metragemComprimento) values 
(LAST_INSERT_ID(),'122', '5', '3');

INSERT INTO tipoMaterial(nome) VALUES('Acetato');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Acetato 144 Micra 2 X 3', 22.99, LAST_INSERT_ID(), 30);
insert into acetato (idTipoMaterial, espessura, metragemAltura, metragemComprimento) values 
(LAST_INSERT_ID(),'144', '2', '3');

INSERT INTO tipoMaterial(nome) VALUES('Acetato');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Acetato 130 Micra 5 X 5', 12.99, LAST_INSERT_ID(), 30);
insert into acetato (idTipoMaterial, espessura, metragemAltura, metragemComprimento) values 
(LAST_INSERT_ID(),'130', '5', '5');

INSERT INTO tipoMaterial(nome) VALUES('Acetato');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Acetato 80 Micra 2 X 3', 12.99, LAST_INSERT_ID(), 30);
insert into acetato (idTipoMaterial, espessura, metragemAltura, metragemComprimento) values 
(LAST_INSERT_ID(),'80', '2', '3');

INSERT INTO tipoMaterial(nome) VALUES('Acetato');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Acetato 166 Micra 3 X 3', 12.99, LAST_INSERT_ID(), 30);
insert into acetato (idTipoMaterial, espessura, metragemAltura, metragemComprimento) values 
(LAST_INSERT_ID(),'166', '5', '3');

#Canudo

INSERT INTO tipoMaterial(nome) VALUES('Canudo');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Canudo Branco 16 Canudo(s)', 0.99, LAST_INSERT_ID(), 150);
insert into canudo values (LAST_INSERT_ID(),'Branco', '16');

INSERT INTO tipoMaterial(nome) VALUES('Canudo');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Canudo Azul 39 Canudo(s)', 0.99, LAST_INSERT_ID(), 150);
insert into canudo values (LAST_INSERT_ID(),'Azul', '39');

INSERT INTO tipoMaterial(nome) VALUES('Canudo');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Canudo Verde 26 Canudo(s)', 2.99, LAST_INSERT_ID(), 150);
insert into canudo values (LAST_INSERT_ID(),'Verde', '26');

INSERT INTO tipoMaterial(nome) VALUES('Canudo');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Canudo Cinza 20 Canudo(s)', 1.99, LAST_INSERT_ID(), 150);
insert into canudo values (LAST_INSERT_ID(),'Cinza', '20');

INSERT INTO tipoMaterial(nome) VALUES('Canudo');
INSERT INTO material (nome, valor, idTipoMaterial, quantidade) VALUES
('Canudo Vermelho 16 Canudo(s)', 2.99, LAST_INSERT_ID(), 150);
insert into canudo values (LAST_INSERT_ID(),'Vermelho', '16');

#Produto

insert into produto (id, nome, valor, tipo, quantidade) values 
(default, 'Caixa sushi', 19.99, 'Cartonagem', 100);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Pérola Branco 5cm'), (SELECT id FROM produto WHERE nome LIKE 'Caixa sushi'), 3);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Papel Fotográfico Branco A3 90'), (SELECT id FROM produto WHERE nome LIKE 'Caixa sushi'), 3);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Renda N 4 m'), (SELECT id FROM produto WHERE nome LIKE 'Caixa sushi'), 3);

insert into produto (id, nome, valor, tipo, quantidade) values 
(default, 'Caixa Canudo', 19.99, 'Cartonagem', 100);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Canudo Verde 26 Canudo(s)'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Canudo'), 3);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Papel Fosco Branco A6 75'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Canudo'), 3);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Fita Voil N° 1 N° Cor 2 B'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Canudo'), 3);

insert into produto (id, nome, valor, tipo, quantidade) values 
(default, 'Caixa Shalker', 15.99, 'Cartonagem', 100);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Papel Colorplus Branco A5 108'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Shalker'), 3);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Fita Voil N° 1 N° Cor 2 B'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Shalker'), 3);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Pérola Branco 5cm'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Shalker'), 3);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Acetato 166 Micra 3 X 3'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Shalker'), 3);

insert into produto (id, nome, valor, tipo, quantidade) values 
(default, 'Caixa Milk', 12.99, 'Cartonagem', 100);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Renda N 4 m'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Milk'), 3);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Pérola Azul 12cm'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Milk'), 3);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Fita Cetim N° 1 N° Cor 4 D'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Milk'), 3);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Papel Colorplus Branco A5 108'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Milk'), 3);

insert into produto (id, nome, valor, tipo, quantidade) values 
(default, 'Caixa Pirâmide', 19.99, 'Cartonagem', 100);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Papel Fosco Branco A4 180'), (SELECT id FROM produto WHERE nome LIKE  'Caixa Pirâmide'), 3);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Fita Gorgurão N° 5 N° Cor 4 A'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Pirâmide'), 3);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Fita Cetim N° 1 N° Cor 4 D'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Pirâmide'), 3);
insert into MaterialProduto(idMaterial, idProduto, quantidade) values ((SELECT idTipoMaterial FROM material WHERE nome LIKE 'Tecido Feltro Estampado 6 cm'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Pirâmide'), 3);

#Cliente 

insert into cliente(id, nome, email, telefone, cep, rua, bairro, numero, cidade, estado, complemento) values (default, 'Vinicius', 'vinicius@gmail.com', '(22)22222-2222', '02129-000', 'Rua Sargento Agostinho Ferreira', 'Vila Maria Alta', '653', 'São Paulo', 'SP', '');

insert into cliente values (default, 'Josias', 'josias@gmail.com', '(99)99999-9999', '07752-010', 'Rua Sebastiana Félix Ribeiro', 'Água Fria', '950', 'Cajamar', 'SP', '');

insert into cliente values (default, 'Rios', 'Rios@gmail.com', '(88)88888-8888', '08502-070', 'Travessa Padre Anchieta', 'Jardim Ferrazense', '520', 'Ferraz de Vasconcelos', 'SP', 'Casa B');

insert into cliente values (default, 'Airton', 'airton@gmail.com', '(77)77777-7777', '14801-743', 'Rua Alfredo Rebuglio', 'Jardim Universal', '625', 'Araraquara', 'SP', 'Casa A');

insert into cliente values (default, 'Vitor', 'vitor@gmail.com', '(11)11111-1111', '06332-400', 'Rua Sucupira', 'Vila Veloso', '820', 'Carapicuíba', 'SP', '');

#Venda

insert into venda(id, nomeCliente, formaPagamento, formaEntrega, valorTotal, anotacao, dataEntrega, dataVenda, codigoCliente) values (default, 'Vinicius', 'Depósito', 'Motoboy', 100.00, 'Anotacao1', '2024-01-20', '2023-11-01', (SELECT id FROM cliente WHERE email LIKE 'vinicius@gmail.com'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 5, (SELECT id FROM venda WHERE nomeCliente LIKE 'Vinicius'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Canudo'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 5, (SELECT id FROM venda WHERE nomeCliente LIKE 'Vinicius'), (SELECT id FROM produto WHERE nome LIKE 'Caixa sushi'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 5, (SELECT id FROM venda WHERE nomeCliente LIKE 'Vinicius'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Shalker'));

insert into venda(id, nomeCliente, formaPagamento, formaEntrega, valorTotal, anotacao, dataEntrega, dataVenda, codigoCliente) values (default, 'Airton', 'Pix', 'Melhor Envio', 120.00, 'Anotacao2', '2024-01-20', '2023-12-01', (SELECT id FROM cliente WHERE email LIKE 'airton@gmail.com'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 7, (SELECT id FROM venda WHERE nomeCliente LIKE 'Airton'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Pirâmide'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 6, (SELECT id FROM venda WHERE nomeCliente LIKE 'Airton'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Milk'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 5, (SELECT id FROM venda WHERE nomeCliente LIKE 'Airton'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Shalker'));

insert into venda(id, nomeCliente, formaPagamento, formaEntrega, valorTotal, anotacao, dataEntrega, dataVenda, codigoCliente) values (default, 'Vitor', 'Depósito', 'Cartão', 90.00, '', '2023-11-10', '2024-01-01', (SELECT id FROM cliente WHERE email LIKE 'vitor@gmail.com'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 7, (SELECT id FROM venda WHERE nomeCliente LIKE 'Vitor'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Pirâmide'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 6, (SELECT id FROM venda WHERE nomeCliente LIKE 'Vitor'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Milk'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 5, (SELECT id FROM venda WHERE nomeCliente LIKE 'Vitor'), (SELECT id FROM produto WHERE nome LIKE 'Caixa sushi'));

insert into venda(id, nomeCliente, formaPagamento, formaEntrega, valorTotal, anotacao, dataEntrega, dataVenda, codigoCliente) values (default, 'Rios', 'Depósito', 'Motoboy', 150.00, 'Anotacao1', '2023-11-23', '2023-12-01', (SELECT id FROM cliente WHERE email LIKE 'Rios@gmail.com'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 7, (SELECT id FROM venda WHERE nomeCliente LIKE 'Rios'), (SELECT id FROM produto WHERE nome LIKE 'Caixa sushi'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 2, (SELECT id FROM venda WHERE nomeCliente LIKE 'Rios'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Milk'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 7, (SELECT id FROM venda WHERE nomeCliente LIKE 'Rios'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Canudo'));

insert into venda(id, nomeCliente, formaPagamento, formaEntrega, valorTotal, anotacao, dataEntrega, dataVenda, codigoCliente) values (default, 'Josias', 'Depósito', 'Motoboy', 79.00, 'Nome Letícia', '2024-01-20', '2023-11-01', (SELECT id FROM cliente WHERE email LIKE 'josias@gmail.com'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 3, (SELECT id FROM venda WHERE nomeCliente LIKE 'Josias'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Pirâmide'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 2, (SELECT id FROM venda WHERE nomeCliente LIKE 'Josias'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Milk'));
insert into vende(id, quantidade, idVenda, idProduto) values (default, 5, (SELECT id FROM venda WHERE nomeCliente LIKE 'Josias'), (SELECT id FROM produto WHERE nome LIKE 'Caixa Shalker'));

#Usuario

INSERT INTO usuario(nome, email, senha) VALUES ("adm", "adm@gmail.com", "adm");
INSERT INTO usuario(nome, email, senha) VALUES ("Dindinha", "dindinha@gmail.com", "1234567");
