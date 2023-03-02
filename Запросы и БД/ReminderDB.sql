USE [master]
CREATE DATABASE RemindersDB;
GO
USE RemindersDB;
CREATE TABLE Reminders (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Title] NVARCHAR(15) NOT NULL,
    [Action] NVARCHAR(100) NOT NULL,
    [ReminderDateTime] VARCHAR(20) NOT NULL,
);
GO
INSERT INTO Reminders ([Title], [Action], [ReminderDateTime]) VALUES (N'Тренировка', N'Пресс качат, Бегит, Турник, Анжуманя', '06:00:00');
INSERT INTO Reminders ([Title], [Action], [ReminderDateTime]) VALUES (N'Тренировка', N'Пресс качат, Бегит, Турник, Анжуманя', '18:00:00');
INSERT INTO Reminders ([Title], [Action], [ReminderDateTime]) VALUES (N'Сельхозработы', N'Посадить грибы', '05.03.2023 16:50:00');
INSERT INTO Reminders ([Title], [Action], [ReminderDateTime]) VALUES (N'Праздник', N'Поесть грибов', '08.03.2023 13:30:00');