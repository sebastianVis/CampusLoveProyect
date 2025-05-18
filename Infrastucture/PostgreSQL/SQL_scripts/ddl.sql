DROP TABLE usuarios CASCADE;
DROP TABLE carrera CASCADE;
DROP TABLE IF EXISTS estadisticas;
DROP TABLE IF EXISTS registros_creditos;
DROP TABLE IF EXISTS matches;
DROP TABLE IF EXISTS interacciones;
DROP TABLE IF EXISTS tipo_interaccion;
DROP TABLE IF EXISTS sesiones_usuario;
DROP TABLE IF EXISTS usuario_interes;
DROP TABLE IF EXISTS usuarios;
DROP TABLE IF EXISTS intereses;
DROP TABLE IF EXISTS genero;
DROP TABLE IF EXISTS login;
DROP TABLE IF EXISTS carrera;
DROP TABLE IF EXISTS usuario_carrera;


CREATE TABLE login (
    id_usuario SERIAL PRIMARY KEY,
    username VARCHAR(20) UNIQUE,
    password VARCHAR(40)
);

CREATE TABLE genero (
    id_genero SERIAL PRIMARY KEY,
    nombre VARCHAR(20) UNIQUE
);

CREATE TABLE intereses (
    id_interes SERIAL PRIMARY KEY,
    nombre VARCHAR(20) UNIQUE
);

CREATE TABLE carrera (
    id_carrera SERIAL PRIMARY KEY,
    nombre VARCHAR(50) UNIQUE
);

CREATE TABLE usuarios (
    id_usuario SERIAL,
    nombre VARCHAR(50),
    edad SMALLINT,
    frase_perfil TEXT,
    id_genero INTEGER REFERENCES genero(id_genero),
    PRIMARY KEY (id_usuario),
    FOREIGN KEY (id_usuario) REFERENCES login(id_usuario)
);

CREATE TABLE usuario_carrera(
    id_carrera SERIAL,
    id_usuario SERIAL,
    PRIMARY KEY(id_carrera, id_usuario),
    FOREIGN KEY (id_carrera) REFERENCES carrera(id_carrera),
    FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario)
);

CREATE TABLE usuario_interes (
    id_usuario INTEGER REFERENCES usuarios(id_usuario),
    id_interes INTEGER REFERENCES intereses(id_interes),
    PRIMARY KEY (id_usuario, id_interes)
);

CREATE TABLE sesiones_usuario (
    id_sesion SERIAL PRIMARY KEY,
    id_usuario SERIAL REFERENCES login(id_usuario),
    fecha_inicio TIMESTAMP,
    fecha_fin TIMESTAMP
);

CREATE TABLE tipo_interaccion (
    id_tipo_interaccion SERIAL PRIMARY KEY,
    interaccion VARCHAR(10)
);

CREATE TABLE interacciones (
    id_interaccion SERIAL PRIMARY KEY,
    id_usuario_emisor INTEGER REFERENCES usuarios(id_usuario),
    id_usuario_receptor INTEGER REFERENCES usuarios(id_usuario),
    id_tipo_interaccion INTEGER REFERENCES tipo_interaccion(id_tipo_interaccion),
    fecha_interaccion TIMESTAMP
);

CREATE TABLE matches (
    id_match SERIAL PRIMARY KEY,
    id_usuario_uno INTEGER REFERENCES usuarios(id_usuario),
    id_usuario_dos INTEGER REFERENCES usuarios(id_usuario),
    fecha_match TIMESTAMP
);

CREATE TABLE registros_creditos (
    id_registro SERIAL PRIMARY KEY,
    id_usuario INTEGER REFERENCES login(id_usuario),
    creditos_anteriores SMALLINT,
    creditos_nuevos SMALLINT,
    motivo VARCHAR(20),
    fecha_registro TIMESTAMP
);

CREATE TABLE estadisticas (
    id_estadistica SERIAL PRIMARY KEY,
    id_usuario INTEGER REFERENCES usuarios(id_usuario),
    likes_recibidos SMALLINT,
    dislikes_recibidos SMALLINT,
    total_matches SMALLINT,
    ultima_actualizacion TIMESTAMP
);