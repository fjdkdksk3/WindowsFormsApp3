CREATE TABLE [dbo].[Пользователи] (
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Логин] NVARCHAR(50) NOT NULL UNIQUE,
    [Пароль] NVARCHAR(100) NOT NULL,
    [Роль] NVARCHAR(20) NOT NULL CHECK (Роль IN ('Администратор', 'Пользователь')),
    [Заблокирован] BIT DEFAULT 0,
    [ДатаСоздания] DATETIME DEFAULT GETDATE(),
    [ДатаПоследнегоВхода] DATETIME NULL
);

-- Добавление тестовых пользователей
INSERT INTO [dbo].[Пользователи] ([Логин], [Пароль], [Роль], [Заблокирован])
VALUES 
('admin', 'admin123', 'Администратор', 0),
('user1', 'user123', 'Пользователь', 0),
('user2', 'user123', 'Пользователь', 1);