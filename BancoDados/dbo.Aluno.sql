Drop Table dbo.Aluno
CREATE TABLE dbo.Aluno
(
	IDAluno INT IDENTITY (1,1) PRIMARY KEY, 
    NomeAluno VARCHAR(50) NOT NULL, 
    DataNascimento DATETIME NOT NULL, 
	IDProfessorResponsavel integer,
)
ALTER TABLE dbo.Aluno
ADD CONSTRAINT AlunoProfessor FOREIGN KEY (IDProfessorResponsavel) REFERENCES dbo.ProfessorResponsavel (IDProfessorResponsavel)

insert into dbo.Aluno(NomeAluno,DataNascimento) VALUES
('Débora', '05-05-2010');


select * from dbo.Aluno