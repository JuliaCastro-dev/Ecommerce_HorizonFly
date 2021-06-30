/*Dropar o banco de dados(Nunca faça isso caso seja realmente nescessário*/
drop database db_horizon;

/*Criando o banco de dados*/
create database db_horizon
default character set utf8
default collate utf8_general_ci;

use db_horizon;

/* Criando a tabela Fucnionário*/
CREATE TABLE Funcionario (
    nome VARCHAR(100),
    senha VARCHAR(10),
    CPF VARCHAR(20) not null unique primary key,
	telefone VARCHAR(20) not null,
	email VARCHAR(150) not null,
	rg VARCHAR(9) not null,
    cargo VARCHAR(50) not null,
    tipo ENUM ('1','2','3','4') not null,
	img VARCHAR(1000)
);

/* Criando a tabela Cliente*/
CREATE TABLE Cliente (
    nome VARCHAR(150) not null,
    telefone VARCHAR(20) not null,
    email VARCHAR(150) not null,
    CPF VARCHAR(20) not null unique primary key,
    rg VARCHAR(9) not null,
    senha VARCHAR(10) not null unique,
    img VARCHAR(1000),
    tipo ENUM ('1','2','3','4') not null
);

/* Criando a tabela Estado*/
CREATE TABLE Estado (
    cd_estado INTEGER not null primary key auto_increment,
    estado VARCHAR(50) not null,
    uf VARCHAR(2) not null
);

/* Criando a tabela Cidade*/
CREATE TABLE Cidade (
    cd_cidade INTEGER not null primary key auto_increment,
    cd_estado INTEGER not null,
    cidade VARCHAR(100) not null,
    FOREIGN KEY (cd_estado) REFERENCES Estado (cd_estado) /*Referencia */
);


CREATE TABLE TipoTransporte (
cd_tipotransporte INTEGER primary key auto_increment,
tipo_transporte VARCHAR(60) -- Ônibus / Avião / Cruzeiro
);

/* Criando a tabela Transporte*/
CREATE TABLE Transporte (
    cd_transporte INTEGER not null primary key auto_increment,
    cidade_transporte INTEGER not null,
    nome_transporte VARCHAR(100) not null,
    cd_tipotransporte INTEGER not null,
    img_transporte VARCHAR(1000) not null,
    FOREIGN KEY (cd_tipotransporte) REFERENCES TipoTransporte(cd_tipotransporte),
     FOREIGN KEY (cidade_transporte) REFERENCES Cidade(cd_cidade)
);

/* Criando a tabela Hotel*/
CREATE TABLE Hotel (
    cd_hotel INTEGER not null primary key auto_increment,
    cd_cidade INTEGER not null,
    nome_hotel VARCHAR(100) not null,
    descricao_hotel VARCHAR(400) not null,
    telefone_hotel VARCHAR(17) not null,
    endereco_hotel VARCHAR(100) not null,
    diaria_hotel VARCHAR(50) not null,
    img_hotel VARCHAR(500) not null,
    FOREIGN KEY (cd_cidade) REFERENCES Cidade (cd_cidade) /*Referencia */
);

/* Criando a tabela Viagem*/
CREATE TABLE Viagem (
    cd_viagem INTEGER not null primary key auto_increment,
    cd_tipotransporte INTEGER not null,
	nome_viagem VARCHAR(100) not null,
    origem INTEGER not null,
    destino INTEGER not null,
    dt_ida DATETIME not null,
    dt_chegada DATETIME not null,
    descricao VARCHAR(400) not null,
    vl_total VARCHAR(50) not null,
    img_viagem VARCHAR(1000) not null,
    FOREIGN KEY (origem) REFERENCES Transporte(cd_transporte) /*Referencia */,
    FOREIGN KEY (destino) REFERENCES Transporte(cd_transporte) /*Referencia */,
    FOREIGN KEY (cd_tipotransporte) REFERENCES TipoTransporte(cd_tipotransporte)
);

/*Criando a tabela categoria */
CREATE TABLE Categoria (
cd_categoria  INTEGER primary key auto_increment,
Categoria VARCHAR(50) null
);


/* Criando a tabela Pacote*/
CREATE TABLE Pacote (
    cd_pacote INTEGER not null primary key auto_increment,
    cd_viagem INTEGER not null,
    cd_hotel INTEGER not null,
    cd_categoria INTEGER  null,
    cd_tipotransporte INTEGER null,
    cd_cidOrigem INTEGER not null,
    cd_cidDestino INTEGER not null,
    nome_pacote VARCHAR(50) not null,
    descricao_pacote VARCHAR(500) not null,
    dtChekin_hotel DATETIME not null,
    dtChekout_hotel DATETIME not null,
    img_pacote VARCHAR(1000) not null,
    vl_pacote   VARCHAR(50)   null,
    FOREIGN KEY (cd_hotel) REFERENCES Hotel (cd_hotel) /*Referencia */,
	FOREIGN KEY (cd_viagem) REFERENCES Viagem(cd_viagem) /*Referencia */,
	FOREIGN KEY (cd_cidOrigem) REFERENCES Cidade(cd_cidade) /*Referencia */,
	FOREIGN KEY (cd_cidDestino) REFERENCES Cidade(cd_cidade) /*Referencia */,
	FOREIGN KEY (cd_categoria) REFERENCES Categoria(cd_categoria) /*Referencia */,
    FOREIGN KEY (cd_tipotransporte) REFERENCES TipoTransporte(cd_tipotransporte)
);

-- criando a tabela tipodetransporte



/* Criando a tabela Cartão */
CREATE TABLE Cartao (
    cd_cartao INTEGER not null primary key auto_increment,
    CPF VARCHAR(20) not null ,
    nome_cartao VARCHAR(80) not null,
    nome_impresso VARCHAR(150) not null, 
    numero_cartao VARCHAR(20) not null,
    cvv_cartao VARCHAR(3) not null,
    validade_cartao DATE not null,
    FOREIGN KEY (CPF) REFERENCES Cliente(CPF) /*Referencia */
);




/* Criando a tabela Reserva*/
CREATE TABLE Reserva (
    cd_reserva INTEGER not null primary key auto_increment,
    CPF VARCHAR(20) not null,
    cd_cartao INTEGER not null,
    vl_total Decimal(14,0) not null,
	status_reserva bit not null,
    FOREIGN KEY (CPF) REFERENCES Cliente (CPF), /*Referencia */
    FOREIGN KEY (cd_cartao) REFERENCES Cartao (cd_cartao) /*Referencia */
);

ALTER TABLE Reserva ADD dthr_reserva datetime;

alter table Reserva
modify vl_total varchar(50) not null;
/* Criando a tabela Itens_Reservas*/
CREATE TABLE ItensReserva(
 cd_itensreserva INTEGER not null primary key auto_increment,
 cd_pacote INTEGER not null,
 cd_reserva INTEGER not null,
 vl_unit VARCHAR(50) not null,
 vl_parcial VARCHAR(50) not null,
 qt_itens INTEGER  not null,
 status_itens bit not null,
 CPF VARCHAR(20) not null,
 FOREIGN KEY (cd_pacote) REFERENCES Pacote (cd_pacote),  /*Referencia */
 FOREIGN KEY (cd_reserva) REFERENCES Reserva (cd_reserva),
  FOREIGN KEY (CPF) REFERENCES Cliente (CPF)  /*Referencia *//*Referencia */
);

Create View ResumoReserva
as select 
Reserva.cd_reserva,
Reserva.dthr_reserva,
Reserva.CPF,
Reserva.cd_cartao,
Reserva.vl_total,
ItensReserva.cd_itensreserva,
ItensReserva.cd_pacote,
ItensReserva.vl_unit,
ItensReserva.qt_itens,
Cliente.nome,
Cartao.nome_cartao,
Pacote.img_pacote,
Pacote.nome_pacote
from Reserva inner join ItensReserva on ItensReserva.cd_reserva = Reserva.cd_reserva
inner join Cliente on Cliente.CPF = Reserva.CPF
inner join Cartao on Cartao.cd_cartao = Reserva.cd_cartao
inner join Pacote on Pacote.cd_pacote = ItensReserva.cd_pacote;
select * from ResumoReserva ;

-- Selecionando as Tabelas ( Selects de cada tabela);

SELECT * FROM Funcionario;
SELECT * FROM Cliente;
SELECT * FROM Viagem;
SELECT * FROM Transporte;
SELECT * FROM tipotransporte;
SELECT * FROM Cartao;
SELECT * FROM Pacote;
SELECT * FROM Hotel;
SELECT * FROM Reserva;
SELECT * FROM ItensReserva;
SELECT * FROM Cidade;
SELECT * FROM Estado;
SELECT * FROM Categoria;



-- Select nome e telefone de clientes e funcionários
SELECT nome,telefone from Cliente;

SELECT nome,telefone from Funcionário;

/* */


-- Views logo Abaixo;
    

Create View Reservas
as select 
Reserva.cd_reserva,
Reserva.dthr_reserva,
Reserva.CPF,
Reserva.cd_cartao,
Reserva.vl_total,
Cliente.nome,
Cartao.nome_cartao
from Reserva
inner join Cliente on Cliente.CPF = Reserva.CPF
inner join Cartao on Cartao.cd_cartao = Reserva.cd_cartao;

/* VIEW DE DETALHES DE Pacote */
CREATE VIEW
-- Nome da View
 DetalhesPacote
as select -- Seleciona
Pacote.cd_pacote,
Pacote.cd_hotel,
Pacote.cd_viagem,
Pacote.nome_pacote,
Pacote.descricao_pacote,
Pacote.dtChekin_hotel,
Pacote.dtChekout_hotel,
Pacote.img_pacote,
Pacote.cd_cidOrigem,
Viagem.destino,
Pacote.vl_pacote,
Hotel.cd_cidade,
Hotel.nome_hotel,
Hotel.descricao_hotel,
Hotel.telefone_hotel,
Hotel.endereco_hotel,
Hotel.diaria_hotel,
Hotel.img_hotel,
Viagem.cd_tipotransporte,
TipoTransporte.tipo_transporte,
Viagem.dt_ida,
Viagem.dt_chegada,
Viagem.vl_total,
Viagem.img_viagem,
Viagem.descricao,
 Transporte.nome_transporte as TransporteDestino,
Cidade.cidade as CidadeOrigem
from Pacote inner join Hotel on Hotel.cd_hotel = Pacote.cd_hotel
inner join Viagem on  Viagem.cd_viagem = Pacote.cd_viagem 
INNER JOIN TipoTransporte  on TipoTransporte.cd_tipotransporte =  Viagem.cd_tipotransporte
inner join Cidade on Cidade.cd_cidade = Pacote.cd_cidOrigem 
inner join Transporte on Transporte.cd_transporte = Viagem.destino 
;

SELECT * FROM DetalhesPacote;
/* VIEW DE TRANSPORTES */
CREATE VIEW
-- Nome da view
 Hoteis
as select -- seleciona
Hotel.cd_cidade,
hotel.cd_hotel,
Hotel.nome_hotel,
Hotel.descricao_hotel,
Hotel.telefone_hotel,
Hotel.endereco_hotel,
Hotel.diaria_hotel,
Hotel.img_hotel,
Cidade.cidade
from Hotel inner join Cidade on Hotel.cd_cidade = Cidade.cd_cidade;

select * from hoteis;

/* VIEW DE HOTEIS */
CREATE VIEW
-- Nome da view
Transportes
as select -- seleciona
Transporte.nome_transporte,
Transporte.cd_tipotransporte,
TipoTransporte.tipo_transporte,
Transporte.img_transporte,
Transporte.cd_transporte,
Cidade.cidade
from Transporte inner join Cidade on Transporte.cidade_transporte = Cidade.cd_cidade 
INNER JOIN TipoTransporte on Transporte.cd_tipotransporte = TipoTransporte.cd_tipotransporte;

select * from Transportes;

CREATE VIEW
-- Nome da view
Cartoes
as select -- seleciona
Cartao.cd_cartao, 
Cartao.CPF,
Cartao.nome_cartao,
Cartao.nome_impresso, 
Cartao.numero_cartao,
Cartao.cvv_cartao,
Cartao.validade_cartao,
Cliente.rg
from Cartao inner join Cliente on Cartao.CPF = Cliente.CPF;


/*VIEW DE VIAGENS */
CREATE VIEW
 vw_MostraViagem
 as select 
 Viagem.cd_viagem,
 Viagem.nome_viagem,
 Viagem.cd_tipotransporte,
 TipoTransporte.tipo_transporte,
 Viagem.nome_viagem as nome,
 Viagem.destino,
 Viagem.dt_ida,
 Viagem.dt_chegada,
 Viagem.descricao,
 Viagem.vl_total,
 Viagem.img_viagem,
Transporte.nome_transporte as TransporteDestino
from Viagem 
INNER JOIN TipoTransporte on TipoTransporte.cd_tipotransporte =  Viagem.cd_tipotransporte inner join Transporte 
on Transporte.cd_transporte = Viagem.destino ;

CREATE VIEW
 vw_MostraViagemDestino
 as select 
 Viagem.cd_viagem,
Transporte.nome_transporte as TransporteDestino
from Viagem 
inner join Transporte on Transporte.cd_transporte = Viagem.destino ;



delimiter //
    drop procedure if exists buscarViagem;
    create procedure buscarViagem()
    begin
        select * from  vw_MostraViagemOrigem;
        select * from vw_MostraViagemDestino;
    end //
delimiter ;

call buscarViagem();


    
    
    delimiter //
    drop procedure if exists SPViagem;
    create procedure SPViagem(
    out Destino VARCHAR(100),
    out Origem VARCHAR(100)
    )
    begin
    declare cdDestino int;
    declare cdOrigem int;
        select (cd_viagem, nome_viagem, cd_tipotransporte, origem as cdOrigem ,destino as cdDestino,  dt_ida, dt_chegada,			descricao, vl_total, img_viagem) from  Viagem;
        
        select max(cidade)  from Cidade where cd_cidade = cdOrigem ;
          select max(cidade)  from Cidade where cd_cidade = cdDestino  ;
    end //
delimiter ;

select *from  Viagem;
        
        select max(cidade)  from Cidade where cd_cidade = cdOrigem ;
          select max(cidade)  from Cidade where cd_cidade = cdDestino  ;
/* */


drop view Resumo_Compra;
select * from Resumo_Compra ;


/* */

-- Procedures logo abaixo;


/* */
drop procedure if exists Login;
-- Procedure para efetuar o login de Funcionário e Cliente (Verificação);
DELIMITER $$
CREATE PROCEDURE 
-- Nome da procedure
Login (-- Parametro de entrada e saida
 IN  VCPF varchar(20), IN VSenha varchar(10)) 
BEGIN
  SELECT * FROM  Funcionario WHERE CPF = VCPF and senha = VSenha;
  SELECT *  FROM Cliente WHERE CPF  = VCPF and senha = VSenha;
END$$
DELIMITER ;
call Login('123.456.789-11','ione123');
call Login('49969549812','jucas2111');


-- procedure de bsucarPacotes
delimiter //
    drop procedure if exists buscarPacote;
    create procedure buscarPacote(
        in Origem varchar(50),
        in Destino varchar(50)
)
    begin
        select * from vw_MostraPacotesOrigem
        where cidade like concat('%',Origem,'%');
        select * from vw_MostraPacotesDestino where cidade like concat('%',Destino,'%');
    end //
delimiter ;
call buscarPacote('aguia branca','aguia');

/* */

-- Funcionário e Cliente alterações de senha;

-- Altera Senha do Funcionário
UPDATE Funcionario SET senha_func = ''
WHERE CPF_func = '' ;


-- Altera Senha do Cliente
UPDATE Cliente SET senha = ''
WHERE cpf_cliente = '';

/* */


-- Esta procedure ira calcular as passagens 
drop procedure if exists Calc_Passagens
DELIMITER $$
CREATE PROCEDURE Calc_Passagens
(
in vn1 decimal(10,2),
in vn2 int
)
begin
 declare resultado decimal(10,2);
 set resultado = vn1 * vn2;
 select resultado as total_Compra;
 end $$
 DELIMITER ;

call Calc_Passagens();



-- Esta procedure ira contar a quantidade GERAL de tudo;
DELIMITER $$
CREATE PROCEDURE 
-- Nome da procedure 
Resumo_Geral (-- Parametro de entrada e saida
OUT quantidadeFuncionarios int, OUT quantidadeClientes int,
OUT quantidadeViagens int ,  OUT quantidadeTransportes int, OUT quantidadePacotes int,
OUT quantidadeReservas int, OUT quantidadeHoteis int)
BEGIN
-- Instrução SQL que realizará a contagem dos seguintes comandos abaixo

Select count(*) INTO quantidadeFuncionarios FROM Funcionario;
Select count(*) INTO quantidadeClientes FROM Cliente;
Select count(*) INTO quantidadeViagens FROM Viagem;
Select count(*) INTO quantidadeTransportes FROM Transporte;
Select count(*) INTO quantidadePacotes FROM Pacote;
Select count(*) INTO quantidadeReservas FROM Reserva;
Select count(*) INTO quantidadeHoteis FROM Hotel;
END$$
DELIMITER  ;


call Resumo_Geral(@quantidadeFuncionarios, @quantidadeClientes, @quantidadeViagens, @quantidadeTransportes, @quantidadePacotes, @quantidadeReservas , @quantidadeHoteis);

select @quantidadeFuncionarios as 'Funcionários', @quantidadeClientes as 'Cliente',
 @quantidadeViagens as 'Viagens', @quantidadeTransportes as 'Transportes', @quantidadePacotes as 'Pacotes', @quantidadeReservas;


DELIMITER $$
CREATE PROCEDURE 
-- Nome da procedure 
ChamaResumo( )
BEGIN
select @quantidadeFuncionarios as 'Funcionários',@quantidadeClientes as 'Clientes',@quantidadeViagens as 'Viagens', @quantidadeTransportes as 'Transportes',
@quantidadePacotes as 'Pacotes', @quantidadeReservas as 'Vendas', @quantidadeHoteis as 'Hoteis'; 

END $$
DELIMITER ;

call ChamaResumo();



/* TRANSACTION */
START TRANSACTION;
INSERT INTO CLiente (nome,senha,CPF,tipo,telefone,email,rg,img) 
VALUES ('Julia','jucas2111','499.695.498-12','4','(11)98053-5577','j@gmail.com','393416136','oi');
UPDATE Funcionario SET tipo = '4'  WHERE CPF = '499.695.498-12';
COMMIT;


/* TRANSACTION */
START TRANSACTION;
SELECT * FROM Funcionario  WHERE CPF = CPF and senha = Senha;
  SELECT * FROM Cliente WHERE CPF  = CPF and senha = Senha;
COMMIT;
delete  from Cliente where CPF = '499.695.178-80';
update funcionario set img = '~/ImagensFuncionario/vitor.jfif' where CPF = '599.695.498-12';
INSERT INTO Funcionario (nome,senha,CPF,cargo,tipo,telefone,email,rg,img) VALUES ('Julia','jucas2111','499.695.498-12','Gerente','1','(11)98053-5577','j@gmail.com','393416136','oi');

Select * from Cidade where cd_cidade = 500;
