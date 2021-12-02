export interface Cliente {
    clienteid: string;
    nome: string;
    email: string;
    telefone: string;
    renda: number;
    nascimento: Date;
    foto: string;
    // caminhoParaFoto: string;
}


export const clienteConverter = {
    toFirestore: (cliente) => {
        return <Cliente>{
            nome: cliente.nome,
            email: cliente.email,
            telefone: cliente.telefone,
            renda: cliente.renda,
            nascimento: cliente.nascimento,
            foto: cliente.foto,
            // caminhoParaFoto: cliente.caminhoParaFoto,
        };
    },
    fromFirestore: (snapshot, options) => {
        const data = snapshot.data(options);
        return <Cliente>{
            clienteid: snapshot.id,
            nome: data.nome,
            email: data.email,
            telefone: data.telefone,
            renda: data.renda,
            nascimento: data.nascimento.toDate(),
            foto: data.foto,
            // caminhoParaFoto: data.caminhoParaFoto,
        }
    }
};