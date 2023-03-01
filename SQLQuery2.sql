USE [master]
CREATE DATABASE RemindersDB;

USE RemindersDB;
CREATE TABLE Reminders (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Title] NVARCHAR(50) NOT NULL,
    [Action] NVARCHAR(100) NOT NULL,
    [ReminderDateTime] VARCHAR(20) NOT NULL,
);
--DELETE FROM Reminders WHERE [Title]='Сельхоз работы';
INSERT INTO Reminders ([Title], [Action], [ReminderDateTime]) VALUES (N'Тренировка', N'Пресс качат, Бегит, Ткрник, Анжуманя', '06:00:00');
INSERT INTO Reminders ([Title], [Action], [ReminderDateTime]) VALUES (N'Тренировка', N'Пресс качат, Бегит, Ткрник, Анжуманя', '18:00:00');
INSERT INTO Reminders ([Title], [Action], [ReminderDateTime]) VALUES (N'Сельхозработы', N'Посадить грибы', '08.03.2023 16:50:00');
INSERT INTO Reminders ([Title], [Action], [ReminderDateTime]) VALUES (N'Социализация', N'Позвать гостей', '05.03.2023 13:30:00');
INSERT INTO Reminders ([Title], [Action], [ReminderDateTime]) VALUES (N'Социализация', N'Съесть грибы с гостями', '05.03.2023 13:30:00');