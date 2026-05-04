namespace ChainOfResponsibilityPattern
{
    class MensalidadeEnriquecimento : IMensalidade
    {
        private IMensalidade _proximo;
        public void Calcular(Matricula matricula)
        {
            if (matricula.TemEnriquecimento)
            {
                matricula.RegistrarAcrescimoMensalidade(200);
                this._proximo.Calcular(matricula);
            }
            else
                this._proximo.Calcular(matricula);
        }

        public void RegistrarProximo(IMensalidade proximo)
        {
            this._proximo = proximo;
        }
    }
}
