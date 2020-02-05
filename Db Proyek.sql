DROP TABLE BARANG CASCADE CONSTRAINT PURGE;
DROP TABLE TEKNISI CASCADE CONSTRAINT PURGE;
DROP TABLE KASIR CASCADE CONSTRAINT PURGE;
DROP TABLE CUSTOMER CASCADE CONSTRAINT PURGE;
DROP TABLE JENIS_SERVICE CASCADE CONSTRAINT PURGE;
DROP TABLE H_JUAL CASCADE CONSTRAINT PURGE;
DROP TABLE D_JUAL CASCADE CONSTRAINT PURGE;
DROP TABLE H_SERVICE CASCADE CONSTRAINT PURGE;
DROP TABLE D_SERVICE CASCADE CONSTRAINT PURGE;

CREATE TABLE BARANG
(
	ID_BARANG VARCHAR2(6) CONSTRAINT PK_BARANG PRIMARY KEY,
	NAMA_BARANG VARCHAR2(100),
	HARGA NUMBER
);

CREATE TABLE TEKNISI
(
	ID_TEKNISI VARCHAR2(6) CONSTRAINT PK_TEKNISI PRIMARY KEY,
	NAMA_TEKNISI VARCHAR2(100),
	ALAMAT VARCHAR2(50),
	TELEPON VARCHAR2(13),
	STATUS NUMBER(1)
);

CREATE TABLE KASIR
(
	ID_KASIR VARCHAR2(6) CONSTRAINT PK_KASIR PRIMARY KEY,
	NAMA_KASIR VARCHAR2(100),
	ALAMAT VARCHAR2(50),
	TELEPON VARCHAR2(13),
	STATUS NUMBER(1),
	PASSWORD VARCHAR2(20)
);

CREATE TABLE CUSTOMER
(
	ID_CUSTOMER VARCHAR2(6) CONSTRAINT PK_CUSTOMER PRIMARY KEY,
	NAMA_CUSTOMER VARCHAR2(100),
	ALAMAT VARCHAR2(50),
	TELEPON VARCHAR2(13),
	STATUS NUMBER(1)
);

CREATE TABLE JENIS_SERVICE
(
	ID_LSERVICE VARCHAR2(6) CONSTRAINT PK_LISTSERVICE PRIMARY KEY,
	NAMA_SERVICE VARCHAR2(100),
	HARGA NUMBER
);

CREATE TABLE H_JUAL
(
	ID_JUAL VARCHAR2(10) CONSTRAINT PK_JUAL PRIMARY KEY,
	TGL_TRANSAKSI DATE,
	TOTAL_JUAL NUMBER,
	ID_KASIR VARCHAR2(6) CONSTRAINT FK_KASIR REFERENCES KASIR(ID_KASIR),
	ID_CUSTOMER VARCHAR2(6)	CONSTRAINT FK_CUSTOMER REFERENCES CUSTOMER(ID_CUSTOMER)
);

CREATE TABLE D_JUAL
(
	ID_JUAL VARCHAR2(10) CONSTRAINT FK_JUAL REFERENCES H_JUAL(ID_JUAL),
	ID_BARANG VARCHAR2(6) CONSTRAINT FK_BARANG REFERENCES BARANG(ID_BARANG),
	SUBTOTAL NUMBER,
	JUMLAH NUMBER,
	CONSTRAINT PK_DJUAL PRIMARY KEY (ID_JUAL, ID_BARANG)
);

CREATE TABLE H_SERVICE
(
	ID_SERVICE VARCHAR2(10) CONSTRAINT PK_SERVICE PRIMARY KEY,
	TGL_TRANSAKSI DATE,
	TOTAL_SERVICE NUMBER,
	ID_KASIR VARCHAR2(6) CONSTRAINT FK_KASIR_SERVICE REFERENCES KASIR(ID_KASIR),
	ID_CUSTOMER VARCHAR2(6)	CONSTRAINT FK_CUSTOMER_SERVICE REFERENCES CUSTOMER(ID_CUSTOMER),
	ID_TEKNISI VARCHAR2(6) CONSTRAINT FK_TEKNISI REFERENCES TEKNISI(ID_TEKNISI),
	ID_LSERVICE VARCHAR2(6) CONSTRAINT FK_LISTSERVICE REFERENCES JENIS_SERVICE(ID_LSERVICE)
);

CREATE TABLE D_SERVICE
(
	ID_SERVICE VARCHAR2(10) CONSTRAINT FK_SERVICE REFERENCES H_SERVICE(ID_SERVICE),
	ID_BARANG VARCHAR2(6) CONSTRAINT FK_BARANG_SERVICE REFERENCES BARANG(ID_BARANG),
	SUBTOTAL NUMBER,
	JUMLAH NUMBER,
	CONSTRAINT PK_DSERVICE PRIMARY KEY (ID_SERVICE)	
);



CREATE OR REPLACE TRIGGER AUTOGEN_CUSTOMER
BEFORE INSERT 
ON CUSTOMER
FOR EACH ROW
DECLARE
	AUTOGEN VARCHAR2(6);
	NAMA VARCHAR2(100);
	IDX NUMBER;
	CTR NUMBER;
BEGIN
	NAMA := UPPER(:NEW.NAMA_CUSTOMER);
	
	IF(INSTR(:NEW.NAMA_CUSTOMER,' ', 1) = 0) THEN
		AUTOGEN := UPPER(SUBSTR(:NEW.NAMA_CUSTOMER,1,2));
	ELSE
		IDX := INSTR(:NEW.NAMA_CUSTOMER,' ', -1);
		AUTOGEN := UPPER(SUBSTR(:NEW.NAMA_CUSTOMER,1,1) || SUBSTR(:NEW.NAMA_CUSTOMER,IDX+1,1));
	END IF;
	
	SELECT COUNT(ID_CUSTOMER) INTO CTR FROM CUSTOMER
	WHERE SUBSTR(ID_CUSTOMER,1,2) LIKE AUTOGEN || '%';
	AUTOGEN := AUTOGEN || LPAD(CTR+1,4,'0');
	:NEW.ID_CUSTOMER := AUTOGEN;
	
END;
/
SHOW ERR;

CREATE OR REPLACE TRIGGER AUTOGEN_TEKNISI
BEFORE INSERT 
ON TEKNISI
FOR EACH ROW
DECLARE
	AUTOGEN VARCHAR2(6);
	NAMA VARCHAR2(100);
	IDX NUMBER;
	CTR NUMBER;
BEGIN
	NAMA := UPPER(:NEW.NAMA_TEKNISI);
	
	IF(INSTR(:NEW.NAMA_TEKNISI,' ', 1) = 0) THEN
		AUTOGEN := UPPER(SUBSTR(:NEW.NAMA_TEKNISI,1,2));
	ELSE
		IDX := INSTR(:NEW.NAMA_TEKNISI,' ', -1);
		AUTOGEN := UPPER(SUBSTR(:NEW.NAMA_TEKNISI,1,1) || SUBSTR(:NEW.NAMA_TEKNISI,IDX+1,1));
	END IF;
	
	SELECT COUNT(ID_TEKNISI) INTO CTR FROM TEKNISI
	WHERE SUBSTR(ID_TEKNISI,1,2) LIKE AUTOGEN || '%';
	AUTOGEN := AUTOGEN || LPAD(CTR+1,4,'0');
	:NEW.ID_TEKNISI := AUTOGEN;
	
END;
/
SHOW ERR;

CREATE OR REPLACE TRIGGER AUTOGEN_KASIR
BEFORE INSERT 
ON KASIR
FOR EACH ROW
DECLARE
	AUTOGEN VARCHAR2(6);
	NAMA VARCHAR2(100);
	IDX NUMBER;
	CTR NUMBER;
BEGIN
	NAMA := UPPER(:NEW.NAMA_KASIR);
	
	IF(INSTR(:NEW.NAMA_KASIR,' ', 1) = 0) THEN
		AUTOGEN := UPPER(SUBSTR(:NEW.NAMA_KASIR,1,2));
	ELSE
		IDX := INSTR(:NEW.NAMA_KASIR,' ', -1);
		AUTOGEN := UPPER(SUBSTR(:NEW.NAMA_KASIR,1,1) || SUBSTR(:NEW.NAMA_KASIR,IDX+1,1));
	END IF;
	
	SELECT COUNT(ID_KASIR) INTO CTR FROM KASIR
	WHERE SUBSTR(ID_KASIR,1,2) LIKE AUTOGEN || '%';
	AUTOGEN := AUTOGEN || LPAD(CTR+1,4,'0');
	:NEW.ID_KASIR := AUTOGEN;
	
END;
/
SHOW ERR;

CREATE OR REPLACE TRIGGER AUTOGEN_BARANG
BEFORE INSERT 
ON BARANG
FOR EACH ROW
DECLARE
	AUTOGEN VARCHAR2(6);
	NAMA VARCHAR2(100);
	IDX NUMBER;
	CTR NUMBER;
BEGIN
	NAMA := UPPER(:NEW.NAMA_BARANG);
	
	IF(INSTR(:NEW.NAMA_BARANG,' ', 1) = 0) THEN
		AUTOGEN := UPPER(SUBSTR(:NEW.NAMA_BARANG,1,2));
	ELSE
		IDX := INSTR(:NEW.NAMA_BARANG,' ', -1);
		AUTOGEN := UPPER(SUBSTR(:NEW.NAMA_BARANG,1,1) || SUBSTR(:NEW.NAMA_BARANG,IDX+1,1));
	END IF;
	
	SELECT COUNT(ID_BARANG) INTO CTR FROM BARANG
	WHERE SUBSTR(ID_BARANG,1,2) LIKE AUTOGEN || '%';
	AUTOGEN := AUTOGEN || LPAD(CTR+1,4,'0');
	:NEW.ID_BARANG := AUTOGEN;
	
END;
/
SHOW ERR;

CREATE OR REPLACE TRIGGER AUTOGEN_SERVICE
BEFORE INSERT 
ON JENIS_SERVICE
FOR EACH ROW
DECLARE
	AUTOGEN VARCHAR2(6);
	NAMA VARCHAR2(100);
	IDX NUMBER;
	CTR NUMBER;
BEGIN
	NAMA := UPPER(:NEW.NAMA_SERVICE);
	
	IF(INSTR(:NEW.NAMA_SERVICE,' ', 1) = 0) THEN
		AUTOGEN := UPPER(SUBSTR(:NEW.NAMA_SERVICE,1,2));
	ELSE
		IDX := INSTR(:NEW.NAMA_SERVICE,' ', -1);
		AUTOGEN := UPPER(SUBSTR(:NEW.NAMA_SERVICE,1,1) || SUBSTR(:NEW.NAMA_SERVICE,IDX+1,1));
	END IF;
	
	SELECT COUNT(ID_LSERVICE) INTO CTR FROM JENIS_SERVICE
	WHERE SUBSTR(ID_LSERVICE,1,2) LIKE AUTOGEN || '%';
	AUTOGEN := AUTOGEN || LPAD(CTR+1,4,'0');
	:NEW.ID_LSERVICE := AUTOGEN;
	
END;
/
SHOW ERR;

INSERT INTO BARANG VALUES ('', 'Accu', 50000);
INSERT INTO BARANG VALUES ('', 'Ban Truk', 175000);
INSERT INTO BARANG VALUES ('', 'Oli Mobil', 75000);
INSERT INTO BARANG VALUES ('', 'Kaca Film', 200000);
INSERT INTO BARANG VALUES ('', 'Ban Biasa', 125000);

INSERT INTO TEKNISI VALUES ('', 'Alfa Christian', 'Jl. Padang Pasir no 76', '081557881258', 1);
INSERT INTO TEKNISI VALUES ('', 'Tonny Salim', 'Jl. Gubeng Kertajaya no 100', '085972652432', 1);
INSERT INTO TEKNISI VALUES ('', 'Wibisono', 'Jl. Manyar Kertajaya no 89', '081231546858', 1);
INSERT INTO TEKNISI VALUES ('', 'Christian Halim', 'Jl. Tugu Pahlawan no 134', '081322547529', 1);
INSERT INTO TEKNISI VALUES ('', 'Dafi Priyadi', 'Jl. Waru no 452', '081550002135', 1);

INSERT INTO KASIR VALUES ('', 'Florensia', 'Jl. Ngagel Jaya Utara no 25', '081233546215', 1, '123456');
INSERT INTO KASIR VALUES ('', 'Akhbar Alim', 'Jl. Dr. Soetomo no 213', '081942361575', 1, '123456');
INSERT INTO KASIR VALUES ('', 'Delima Dea', 'Jl. Manyar Kertoadi no 15', '081675214985', 1, '123456');
INSERT INTO KASIR VALUES ('', 'Ahmad Adijaya', 'Jl. Bratang Binangun no 75', '085546852197', 1, '123456');
INSERT INTO KASIR VALUES ('', 'Putra Agung', 'Jl. Pucang Anom Timur no 123', '087757456852', 1, '123456');

INSERT INTO CUSTOMER VALUES ('', 'Davin Airlangga', 'Jl. Polisi Istimewa no 1', '087756855412', 1);
INSERT INTO CUSTOMER VALUES ('', 'Ivan Karijadi', 'Jl. Siwalan Kerto no 68', '081384962570', 1);
INSERT INTO CUSTOMER VALUES ('', 'Valentina', 'Jl. Sulawesi no 69', '087765498201', 1);
INSERT INTO CUSTOMER VALUES ('', 'Lukman Salam', 'Jl. Mangrove no 103', '081034518840', 1);
INSERT INTO CUSTOMER VALUES ('', 'Michael Tenoyo', 'Jl. Ngagel Wasana I no 45', '087024850505', 1);

INSERT INTO JENIS_SERVICE VALUES ('', 'Servis', 50000);
INSERT INTO JENIS_SERVICE VALUES ('', 'Ganti Oli', 25000);
INSERT INTO JENIS_SERVICE VALUES ('', 'Tambal Ban', 15000);
INSERT INTO JENIS_SERVICE VALUES ('', 'Ganti Ban', 10000);
INSERT INTO JENIS_SERVICE VALUES ('', 'Outing', 800000);
INSERT INTO JENIS_SERVICE VALUES ('', 'Beli Barang', 0);

COMMIT;