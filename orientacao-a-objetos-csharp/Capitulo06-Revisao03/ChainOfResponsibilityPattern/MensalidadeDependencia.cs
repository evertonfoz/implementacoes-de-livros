namespace ChainOfResponsibilityPattern
{
    class MensalidadeDependencia : IMensalidade
    {
        private IMensalidade _proximo;
        public void Calcular(Matricula matricula)
        {
            if (matricula.TemDependencia)
            {
                matricula.RegistrarAcrescimoMensalidade(500);
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
