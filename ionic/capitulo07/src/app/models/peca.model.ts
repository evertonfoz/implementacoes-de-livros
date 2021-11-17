import { Guid } from 'guid-typescript';

export interface Peca {
    id: Guid;
    nome: string;
    valor: number;
}