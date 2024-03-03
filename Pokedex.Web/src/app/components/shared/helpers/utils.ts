import moment from 'moment';

export function formatarData(data: string): string {
    return moment(data).format('DD/MM/YYYY HH:mm:ss');
}
