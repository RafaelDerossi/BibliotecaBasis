CREATE VIEW [dbo].[ViewLivro]
AS
SELECT dbo.Livro.Id, dbo.Livro.Titulo, dbo.Livro.Editora, dbo.Livro.Edicao, dbo.Livro.AnoPublicacao, dbo.Livro.DataDeCadastro, dbo.Livro.DataDeAlteracao, dbo.Livro.Lixeira, dbo.Autor.Id AS AutorId, dbo.Autor.Nome AS AutorNome, dbo.Assunto.Id AS AssuntoId, 
             dbo.Assunto.Descricao AS AssuntoDescricao
FROM   dbo.AutorLivro INNER JOIN
             dbo.Autor ON dbo.AutorLivro.AutoresId = dbo.Autor.Id INNER JOIN
             dbo.Livro INNER JOIN
             dbo.AssuntoLivro ON dbo.Livro.Id = dbo.AssuntoLivro.LivrosId INNER JOIN
             dbo.Assunto ON dbo.AssuntoLivro.AssuntosId = dbo.Assunto.Id ON dbo.AutorLivro.LivrosId = dbo.Livro.Id





