using FluentValidation.Results;

namespace BibliotecaBasis.Comum.ObjetosDeDominio
{
    public abstract class Entidade
    {
        public Guid Id { get; private set; }
        public DateTime DataDeCadastro { get; private set; }
        public DateTime DataDeAlteracao { get; private set; }
        public bool Lixeira { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = new ValidationResult();



        protected void AdicionarErrosDaEntidade(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }
            
        

        public void SetEntidadeId(Guid NovoId) => Id = NovoId;

        public void SetDataDeCadastro(DateTime data) => DataDeCadastro = data;

        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;

        public Entidade()
        {
            Id = Guid.NewGuid();
            DataDeCadastro = DateTime.Now;
            DataDeAlteracao = DateTime.Now;
        }


        #region Comparações

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entidade;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entidade a, Entidade b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entidade a, Entidade b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        #endregion
    }
}
