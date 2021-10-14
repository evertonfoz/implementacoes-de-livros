import { SQLiteDBConnection } from '@capacitor-community/sqlite';

export async function deleteDatabase(db: SQLiteDBConnection): Promise<void> {
  try {
    console.log('a');
    let ret: any = await db.isExists();
    console.log('b');
    if (ret.result) {
      console.log('c');
      const dbName = db.getConnectionDBName();
      console.log('d');
      await db.delete();
      console.log('e');
      return Promise.resolve();
    } else {
      console.log('f');
      return Promise.resolve();
    }
  } catch (err) {
    console.log('g');
    return Promise.reject(err);
  }
}
