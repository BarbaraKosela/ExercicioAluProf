Drop table dbo.ProfessorResponsavel
CREATE TABLE dbo.ProfessorResponsavel
(
	IDProfessorResponsavel INT IDENTITY (1,1) PRIMARY KEY, 
    NomeProfessor VARCHAR(50) NOT NULL,
	IDAluno integer,
)
ALTER TABLE dbo.ProfessorResponsavel
ADD CONSTRAINT ProfessorAluno FOREIGN KEY (IDAluno) REFERENCES dbo.Aluno (IDAluno)

insert into dbo.ProfessorResponsavel(NomeProfessor) VALUES
('Cristhian');