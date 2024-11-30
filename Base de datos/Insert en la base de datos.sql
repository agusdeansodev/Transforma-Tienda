INSERT INTO MARCAS (Descripcion) VALUES ('Bosh');
INSERT INTO MARCAS (Descripcion) VALUES ('Motorola');
INSERT INTO MARCAS (Descripcion) VALUES ('Royal Kludge');
INSERT INTO MARCAS (Descripcion) VALUES ('Wilson');
INSERT INTO MARCAS (Descripcion) VALUES ('Logitech');
INSERT INTO MARCAS (Descripcion) VALUES ('Samsung');
INSERT INTO MARCAS (Descripcion) VALUES ('Sony');
INSERT INTO MARCAS (Descripcion) VALUES ('Apple');
INSERT INTO MARCAS (Descripcion) VALUES ('Nike');
INSERT INTO MARCAS (Descripcion) VALUES ('Adidas');
INSERT INTO MARCAS (Descripcion) VALUES ('Puma');
INSERT INTO MARCAS (Descripcion) VALUES ('Madre Terra');

----------------------------------------------------------------------------------------------------------------------
INSERT INTO CATEGORIAS (Descripcion) VALUES 
('Mochilas'),
('Perifericos'),
('Accesorios'),
('Ropa Deportiva'),
('Electrodomesticos'),
('Libros'),
('Juguetes'),
('Muebles'),
('Herramientas'),
('Joyeria'),
('Calzado'),
('Alimentos');

----------------------------------------------------------------------------------------------------------------------
INSERT INTO rol (descripcion)
VALUES
('Administrador'),
('Usuario');

----------------------------------------------------------------------------------------------------------------------
INSERT INTO usuario (nombreUsuario, clave, idRol, nombre, apellido, correo, telefono, esActivo, fechaRegistro)
VALUES
('Usuario', '12345', 2, 'Marta', 'Rojas', 'martaRojas@example.com', '987654321', 1, GETDATE()), 
('Usuario2', '12345', 2, 'Juan', 'Perez', 'juanPerez@example.com', '123456789', 1, GETDATE()),
('Usuario3', '12345', 2, 'Esteban', 'Quito', 'EstebanQuito@example.com', '321456789', 1, GETDATE()),
('Admin1', '1234', 1, 'Agus', 'Perez', 'AgusPerez@example.com', '987456789', 1, GETDATE());

----------------------------------------------------------------------------------------------------------------------
INSERT INTO ARTICULOS (IdUsuario, Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio, Stock)
VALUES 
(1, 'M01', 'Mochila Porta Notebook', 'Esta mochila combina un diseno elegante y profesional con la robustez necesaria para enfrentar el ajetreo urbano y los viajes de negocios.', 1, 1, 49999, 10),
(1, 'P03', 'Mouse Gamer Hero G502', 'Sumergite en el mundo de los videojuegos con el mouse gamer Logitech G Series Hero G502 en color negro', 2, 2, 64999, 10),
(1, 'P08', 'Teclado Mecanico 75% Rk M75', 'Este teclado cuenta con un diseno compacto con 81 teclas, por lo que es facil de transportar y usar en cualquier lugar.', 3, 3, 185000, 10),
(1, 'R10', 'Camiseta Deportiva Nike', 'Camiseta deportiva Nike con tecnologia de secado rapido.', 4, 4, 32999, 10),
(1, 'E15', 'Aspiradora Inteligente Samsung', 'Aspiradora inteligente con control remoto y programacion.', 5, 5, 199999, 10),
(1, 'L23', 'Libro de Cocina Gourmet', 'Un libro de cocina con recetas gourmet de todo el mundo.', 6, 6, 5999, 10),
(2, 'J40', 'Muñeca Barbie Edicion Especial', 'Muñeca Barbie edicion especial coleccionable.', 7, 7, 45999, 10),
(2, 'M55', 'Sofa Modular', 'Sofa modular con diseno contemporaneo y tejido de alta calidad.', 8, 8, 349999, 10),
(2, 'H65', 'Taladro Inalambrico Bosch', 'Taladro inalambrico con bateria de larga duracion.', 9, 9, 79999, 10),
(3, 'J77', 'Collar de Plata Estrella', 'Collar de plata con colgante en forma de estrella.', 10, 10, 19999, 10),
(3, 'C89', 'Zapatillas Adidas Running', 'Zapatillas de running con suela de alto rendimiento.', 11, 11, 89999, 10),
(3, 'A100', 'Pack de Alimentos Organicos', 'Pack de alimentos organicos para una alimentacion saludable.', 12, 12, 29999, 10);

-----------------------------------------------------------------

insert into imagenes (IdArticulo, ImagenUrl)
VALUES
(1,'https://http2.mlstatic.com/D_NQ_NP_703368-MLU76300898146_052024-O.webp'),
(1, 'https://http2.mlstatic.com/D_NQ_NP_842545-MLU76300482840_052024-O.webp'),
(1, 'https://http2.mlstatic.com/D_NQ_NP_747302-MLU76300769244_052024-O.webp'),
(2, 'https://http2.mlstatic.com/D_NQ_NP_701613-MLA45464844877_042021-O.webp'),
(2, 'https://http2.mlstatic.com/D_NQ_NP_987670-MLA45464844880_042021-O.webp'),
(2, 'https://http2.mlstatic.com/D_NQ_NP_793119-MLU72761228270_112023-O.webp'),
(3, 'https://http2.mlstatic.com/D_NQ_NP_767460-MLA74282172500_022024-O.webp'),
(3, 'https://http2.mlstatic.com/D_NQ_NP_848157-MLA74517144673_022024-O.webp'),
(3, 'https://http2.mlstatic.com/D_NQ_NP_616027-MLA74397845971_022024-O.webp'),
(4, 'https://d2ne65t3epzl8v.cloudfront.net/Custom/Content/Products/99/76/997663_camiseta-nike-sportswear-tee-brand-mark-masculina-12602_m1_637164157736465663.jpg'),---camiseta nike
(4, 'https://d2ne65t3epzl8v.cloudfront.net/Custom/Content/Products/99/76/997663_camiseta-nike-sportswear-tee-brand-mark-masculina-12602_m2_637164250680197207.jpg'),
(4, 'https://d2ne65t3epzl8v.cloudfront.net/Custom/Content/Products/99/76/997663_camiseta-nike-sportswear-tee-brand-mark-masculina-12602_m1_637164157736465663.jpg'),
(5, 'https://fujiokadistribuidor.vteximg.com.br/arquivos/ids/183670'),---aspiradora inteligente samsumng
(5, 'https://fujiokadistribuidor.vteximg.com.br/arquivos/ids/183671'),
(5, 'https://fujiokadistribuidor.vteximg.com.br/arquivos/ids/183673'),
(6, 'https://images.cdn2.buscalibre.com/fit-in/360x360/6a/d4/6ad46b1f5da447f5e580134b3ab2fda1.jpg'),--libro de cocina gourmet
(6, 'https://http2.mlstatic.com/D_NQ_NP_921630-MCO45200601272_032021-O.webp'),
(6, 'https://http2.mlstatic.com/D_NQ_NP_833290-MCO45200599281_032021-O.webp'),
(7, 'https://scontent.fccm8-1.fna.fbcdn.net/v/t1.6435-9/93771626_1419267178245105_8804552926665113600_n.jpg?stp=dst-jpg_p552x414&_nc_cat=107&ccb=1-7&_nc_sid=833d8c&_nc_ohc=ToUzmjGGyugQ7kNvgFe9Cfd&_nc_zt=23&_nc_ht=scontent.fccm8-1.fna&_nc_gid=AD1Y3XQKG5y7sbaLU8TKBj9&oh=00_AYBvNNJjROgkt4RxP0moJQBgIOW5qyJABw9-v13E1x9lxg&oe=675AF3F4'),--muñeca barbi edicion especial
(7, 'https://www.vostv.com.ni/media/uploads/2023/08/08/mattel-barbie-rarita-.jpeg'),
(7, 'https://media.vogue.es/photos/5cc765e6a6e117d2d554e17d/master/w_1600,c_limit/news_barbie_videojuegos_8652.jpg'),
(8, 'https://cdn.leroymerlin.com.br/products/sofa_modular_hug_6_lugares_380cm_com_2_puffs_em_linho_cabecas_1567568135_c5b9_600x600.jpg'),--sofa modular
(8, 'https://cdn.leroymerlin.com.br/products/sofa_modular_hug_6_lugares_380cm_com_2_puffs_em_linho_cabecas_1567568135_63b5_600x600.jpg'),
(8, 'https://cdn.leroymerlin.com.br/products/sofa_modular_hug_6_lugares_380cm_com_2_puffs_em_linho_cabecas_1567568135_a2bb_600x600.jpg'),
(9, 'https://inalambricosperu.vtexassets.com/arquivos/ids/172118-1600-auto?v=638284440474100000&width=1600&height=auto&aspect=true'),--taladro inalambrico
(9, 'https://inalambricosperu.vtexassets.com/arquivos/ids/172122-1600-auto?v=638284440482670000&width=1600&height=auto&aspect=true'),
(9, 'https://inalambricosperu.vtexassets.com/arquivos/ids/172124-1600-auto?v=638284440489230000&width=1600&height=auto&aspect=true'),
(10, 'https://pandoraar.vtexassets.com/arquivos/ids/324407/390020C01_1.png?v=638356882658470000'),-- collar de plata estrella
(10, 'https://pandoraar.vtexassets.com/arquivos/ids/324409/390020C01_3.png?v=638356882664300000'),
(10, 'https://pandoraar.vtexassets.com/arquivos/ids/324410/390020C01_4.png?v=638356882667600000'),
(11, 'https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/5f71ff9dd6964eb4b92273eb75e27d72_9366/Tenis_Corrida_Switch_Run_Azul_IF5713_02_standard_hover.jpg'),--zapatillas adidas running
(11, 'https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/a2891d8b73bd43af902c2e9b51c1d992_9366/Tenis_Corrida_Switch_Run_Azul_IF5713_04_standard.jpg'),
(11, 'https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/61a20037811147e8b820bc5474709eca_9366/Tenis_Corrida_Switch_Run_Azul_IF5713_03_standard.jpg'),
(12, 'https://www.cdn.ciorganicos.com.br/wp-content/uploads/2018/05/mae_terra.jpg'),--pack de alimentos organicos
(12, 'https://redemix.vteximg.com.br/arquivos/ids/212933-500-500/7896496917013.jpg?v=638350619828900000'),
(12, 'https://zonasul.vtexassets.com/arquivos/ids/3101093/VF4qT-qqCUAAAAAAAATYvg.jpg?v=638282430470870000');
