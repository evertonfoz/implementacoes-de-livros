namespace ChainOfResponsibilityPattern
{
    public class MensalidadeRegular : IMensalidade
    {
        private IMensalidade _proximo;
        public void Calcular(Matricula matricula)
        {
            if (matricula.TemRegulares)
            {
                matricula.RegistrarAcrescimoMensalidade(1000);
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
