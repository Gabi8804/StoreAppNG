 /*
 
 Do not change order of inserts
 



 Prepare tables so UI can use it
 */
 
 
 insert into Brands
  values ('Samsung'),('LG'),('Phillips'),('Dell'),('Asus'),('HP'),('Lenovo'),('Apple'),('Huawei')

  insert into Categories
  values('TV'),('Laptop'),('Smartphone')

   
 insert into BrandCategories (CategoryId,BrandId) values
 (1,1),(1,2),(1,3),(2,4),(2,5),(2,6),(2,7),(3,1),(3,2),(3,8),(3,9)

 insert into Specs values
 ('Dimensiune Ecran'),('Format display'),('Rezolutie ecran'),('Sistem Operare'),('Culoare'),('Consum Energie'),
 ('Procesor'),('Memorie RAM'),('Stocare'),('Placă video'),('Baterie'),('Tip SIM'),('Slot Sim'),
	('Durata convorbire'),('Rezolutie camera')

	 insert into CategorySpecs (CategoryId,SpecId)
 values(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(2,1),(2,2),(2,3),(2,4),(2,5),(2,7),(2,8),(2,9)
 ,(2,10),(2,11),(2,15),(3,1),(3,2),(3,3),(3,4),(3,5),(3,7),
 (3,8),(3,9),(3,11),(3,12),(3,13),(3,14),(3,15)

 /*
 
 Insert product and it's specifications
 

 */

  insert into Products
  ([Name],[Description],Price,BrandCategoryId, Quantity)
  values
  ('Laptop Asus ROG G15 G512LI',
  'Modelul ROG Strix G15 reprezinta emblema stilului elegant si subtil, oferind o experienta de utilizare formidabila pentru jocuri foarte serioase.',10,
  4.299,5)

  INSERT INTO [dbo].[Prod_CatSpec]
           ([ProductId]
           ,[CategorySpecsId]
           ,[SpecValue])
     VALUES
           (1,8,'15.6 inch')
		   ,(1,9,'Full HD')
		   ,(1,10,'1920 x 1080')
		   ,(1,11,'Free DOS')
		   ,(1,12,'Negru')
		   ,(1,13,'Intel® Core™ i5-10300H pana la 4.50 GHz')
		   ,(1,14,'8 GB')
		   ,(1 ,15,'512 GB SSD')
		   ,(1,16,'nVidia GeForce GTX 1650 Ti')
		   ,(1,17,'Baterie 3 celule - 48Wh')
		   ,(1,18,'-')
GO


  insert into [SmartStoreDB].[dbo].[AspNetRoles]
  ([Name],[NormalizedName])
  values
  ('Admin','ADMIN')