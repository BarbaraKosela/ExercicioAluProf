Drop Table dbo.Aluno
CREATE TABLE dbo.Aluno
(
	IDAluno INT NOT NULL PRIMARY KEY, 
    NomeAluno VARCHAR(50) NOT NULL, 
    DataNascimento DATETIME NOT NULL, 
	IDProfessorResponsavel integer,
    CONSTRAINT AlunoProfessor foreign key (IDProfessorResponsavel) References dbo.ProfessorResponsavel (IDProfessorResponsavel)
)
