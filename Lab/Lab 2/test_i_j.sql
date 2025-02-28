USE QLBongDa
GO
EXEC SPCau1 N'SHB Đà Nẵng', 'Brazil'
EXEC SPCau2 3, 2009
EXEC SPCau3 N'Việt Nam'
EXEC SPCau4 N'Việt Nam', 2
EXEC SPCau5 N'Tiền đạo'
EXEC SPCau6 3, 2009
EXEC SPCau7
EXEC SPCau8 N'Việt Nam'
EXEC SPCau9 3, 2009
EXEC SPCau10 3, 2009

-- I
-- BDRead
SELECT * FROM vCau1
SELECT * FROM vCau5

-- BDU01
SELECT * FROM vCau2
SELECT * FROM vCau10

-- BDU03
SELECT * FROM vCau1
SELECT * FROM vCau2
SELECT * FROM vCau3
SELECT * FROM vCau4

-- BDU04
SELECT * FROM vCau1
SELECT * FROM vCau2
SELECT * FROM vCau3
SELECT * FROM vCau4

-- J
-- BDRead 
EXEC SPCau1 N'SHB Đà Nẵng', 'Brazil'
EXEC SPCau9 3, 2009
-- BDU01 
EXEC SPCau3 N'Việt Nam'
EXEC SPCau10 3, 2009
-- BDU03 
EXEC SPCau1 N'SHB Đà Nẵng', 'Brazil'
EXEC SPCau10 3, 2009
EXEC SPCau3 N'Việt Nam'
EXEC SPCau4 N'Việt Nam', 2
-- BDU04 
EXEC SPCau1 N'SHB Đà Nẵng', 'Brazil'
EXEC SPCau10 3, 2009
EXEC SPCau3 N'Việt Nam'
EXEC SPCau4 N'Việt Nam', 2