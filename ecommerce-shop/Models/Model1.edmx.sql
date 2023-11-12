
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/11/2023 09:45:42
-- Generated from EDMX file: D:\myproject\MVC\ecommerce-shop\ecommerce-shop\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBQLEcommerceShop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__ChiTietHo__idHoa__0D44F85C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChiTietHoaDon] DROP CONSTRAINT [FK__ChiTietHo__idHoa__0D44F85C];
GO
IF OBJECT_ID(N'[dbo].[FK__ChiTietHo__Thanh__0C50D423]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChiTietHoaDon] DROP CONSTRAINT [FK__ChiTietHo__Thanh__0C50D423];
GO
IF OBJECT_ID(N'[dbo].[FK__HoaDon__TongTien__09746778]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HoaDon] DROP CONSTRAINT [FK__HoaDon__TongTien__09746778];
GO
IF OBJECT_ID(N'[dbo].[FK__SanPham__GhiChu__0697FACD]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SanPham] DROP CONSTRAINT [FK__SanPham__GhiChu__0697FACD];
GO
IF OBJECT_ID(N'[dbo].[FK_PhanQuyen_ChucNang]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhanQuyen] DROP CONSTRAINT [FK_PhanQuyen_ChucNang];
GO
IF OBJECT_ID(N'[dbo].[FK_PhanQuyen_NhanVien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhanQuyen] DROP CONSTRAINT [FK_PhanQuyen_NhanVien];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ChatLieu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChatLieu];
GO
IF OBJECT_ID(N'[dbo].[ChiTietHoaDon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChiTietHoaDon];
GO
IF OBJECT_ID(N'[dbo].[ChucNang]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChucNang];
GO
IF OBJECT_ID(N'[dbo].[HoaDon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HoaDon];
GO
IF OBJECT_ID(N'[dbo].[KhachHang]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KhachHang];
GO
IF OBJECT_ID(N'[dbo].[NhaCungCap]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NhaCungCap];
GO
IF OBJECT_ID(N'[dbo].[NhanVien]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NhanVien];
GO
IF OBJECT_ID(N'[dbo].[PhanQuyen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhanQuyen];
GO
IF OBJECT_ID(N'[dbo].[SanPham]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SanPham];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ChucNangs'
CREATE TABLE [dbo].[ChucNangs] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TenChucNang] nvarchar(100)  NULL,
    [MaChucNang] nvarchar(100)  NULL
);
GO

-- Creating table 'NhanViens'
CREATE TABLE [dbo].[NhanViens] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Username] varchar(50)  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [TenNhanVien] nvarchar(50)  NULL,
    [SDT] nvarchar(50)  NULL,
    [NgaySinh] datetime  NULL,
    [idLoaiNhanVien] int  NULL,
    [ChucVu] nvarchar(50)  NULL
);
GO

-- Creating table 'PhanQuyens'
CREATE TABLE [dbo].[PhanQuyens] (
    [idNhanVien] int  NOT NULL,
    [idChucNang] int  NOT NULL,
    [GhiChu] nvarchar(50)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Username] varchar(200)  NOT NULL,
    [Password] nvarchar(200)  NOT NULL,
    [Email] varchar(200)  NULL,
    [HoVaTen] nvarchar(200)  NOT NULL,
    [SoDienThoai] nvarchar(50)  NOT NULL,
    [RePassword] nvarchar(200)  NULL
);
GO

-- Creating table 'NhaCungCaps'
CREATE TABLE [dbo].[NhaCungCaps] (
    [ID] int  NOT NULL,
    [TenNhaCungCap] nvarchar(200)  NULL,
    [DiaChiNhaCungCap] nvarchar(200)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'ChatLieux'
CREATE TABLE [dbo].[ChatLieux] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TenChatLieu] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'ChiTietHoaDons'
CREATE TABLE [dbo].[ChiTietHoaDons] (
    [idHoaDon] int  NOT NULL,
    [idSanPham] int  NOT NULL,
    [SoLuong] int  NOT NULL,
    [DonGia] int  NOT NULL,
    [GiamGia] int  NOT NULL,
    [ThanhTien] int  NOT NULL
);
GO

-- Creating table 'HoaDons'
CREATE TABLE [dbo].[HoaDons] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [idNhanVien] int  NULL,
    [NgayBan] datetime  NULL,
    [idKhachHang] int  NOT NULL,
    [TongTien] int  NOT NULL
);
GO

-- Creating table 'KhachHangs'
CREATE TABLE [dbo].[KhachHangs] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TenKhach] nvarchar(100)  NOT NULL,
    [DiaChi] nvarchar(300)  NOT NULL,
    [SoDienThoai] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'SanPhams'
CREATE TABLE [dbo].[SanPhams] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TenSanPham] nvarchar(200)  NOT NULL,
    [idChatLieu] int  NOT NULL,
    [SoLuong] int  NOT NULL,
    [GiaBan] int  NOT NULL,
    [HinhAnh] nvarchar(200)  NULL,
    [GhiChu] nvarchar(200)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'ChucNangs'
ALTER TABLE [dbo].[ChucNangs]
ADD CONSTRAINT [PK_ChucNangs]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'NhanViens'
ALTER TABLE [dbo].[NhanViens]
ADD CONSTRAINT [PK_NhanViens]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [idNhanVien], [idChucNang] in table 'PhanQuyens'
ALTER TABLE [dbo].[PhanQuyens]
ADD CONSTRAINT [PK_PhanQuyens]
    PRIMARY KEY CLUSTERED ([idNhanVien], [idChucNang] ASC);
GO

-- Creating primary key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'NhaCungCaps'
ALTER TABLE [dbo].[NhaCungCaps]
ADD CONSTRAINT [PK_NhaCungCaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'ChatLieux'
ALTER TABLE [dbo].[ChatLieux]
ADD CONSTRAINT [PK_ChatLieux]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [idHoaDon], [idSanPham] in table 'ChiTietHoaDons'
ALTER TABLE [dbo].[ChiTietHoaDons]
ADD CONSTRAINT [PK_ChiTietHoaDons]
    PRIMARY KEY CLUSTERED ([idHoaDon], [idSanPham] ASC);
GO

-- Creating primary key on [ID] in table 'HoaDons'
ALTER TABLE [dbo].[HoaDons]
ADD CONSTRAINT [PK_HoaDons]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'KhachHangs'
ALTER TABLE [dbo].[KhachHangs]
ADD CONSTRAINT [PK_KhachHangs]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SanPhams'
ALTER TABLE [dbo].[SanPhams]
ADD CONSTRAINT [PK_SanPhams]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idChucNang] in table 'PhanQuyens'
ALTER TABLE [dbo].[PhanQuyens]
ADD CONSTRAINT [FK_PhanQuyen_ChucNang]
    FOREIGN KEY ([idChucNang])
    REFERENCES [dbo].[ChucNangs]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhanQuyen_ChucNang'
CREATE INDEX [IX_FK_PhanQuyen_ChucNang]
ON [dbo].[PhanQuyens]
    ([idChucNang]);
GO

-- Creating foreign key on [idNhanVien] in table 'PhanQuyens'
ALTER TABLE [dbo].[PhanQuyens]
ADD CONSTRAINT [FK_PhanQuyen_NhanVien]
    FOREIGN KEY ([idNhanVien])
    REFERENCES [dbo].[NhanViens]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idChatLieu] in table 'SanPhams'
ALTER TABLE [dbo].[SanPhams]
ADD CONSTRAINT [FK__SanPham__GhiChu__0697FACD]
    FOREIGN KEY ([idChatLieu])
    REFERENCES [dbo].[ChatLieux]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SanPham__GhiChu__0697FACD'
CREATE INDEX [IX_FK__SanPham__GhiChu__0697FACD]
ON [dbo].[SanPhams]
    ([idChatLieu]);
GO

-- Creating foreign key on [idHoaDon] in table 'ChiTietHoaDons'
ALTER TABLE [dbo].[ChiTietHoaDons]
ADD CONSTRAINT [FK__ChiTietHo__idHoa__0D44F85C]
    FOREIGN KEY ([idHoaDon])
    REFERENCES [dbo].[HoaDons]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idSanPham] in table 'ChiTietHoaDons'
ALTER TABLE [dbo].[ChiTietHoaDons]
ADD CONSTRAINT [FK__ChiTietHo__Thanh__0C50D423]
    FOREIGN KEY ([idSanPham])
    REFERENCES [dbo].[SanPhams]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ChiTietHo__Thanh__0C50D423'
CREATE INDEX [IX_FK__ChiTietHo__Thanh__0C50D423]
ON [dbo].[ChiTietHoaDons]
    ([idSanPham]);
GO

-- Creating foreign key on [idKhachHang] in table 'HoaDons'
ALTER TABLE [dbo].[HoaDons]
ADD CONSTRAINT [FK__HoaDon__TongTien__09746778]
    FOREIGN KEY ([idKhachHang])
    REFERENCES [dbo].[KhachHangs]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__HoaDon__TongTien__09746778'
CREATE INDEX [IX_FK__HoaDon__TongTien__09746778]
ON [dbo].[HoaDons]
    ([idKhachHang]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------