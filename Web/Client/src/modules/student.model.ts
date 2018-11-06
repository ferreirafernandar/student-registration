import { Guid } from "guid-typescript";

export class Student {
    studentId: string;
    name: string;
    cpf: string;
    phones: [
      {
        number: string;
        tipo: number;
      }
    ];
  }