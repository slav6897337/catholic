import {IHeader} from '../Domain/IHeader';
import log from './Logging';

function getHeaders(additionalHeaders?: IHeader[]): Headers {
  const headers = new Headers();
  headers.append('Content-Type', 'application/json');
  headers.append('Accept', 'application/json');
  if (additionalHeaders && additionalHeaders.length) {
    additionalHeaders.forEach(h => headers.append(h.key, h.value));
  }
  return headers;
}

function request<T>(url: string, method: string, body?: any, additionalHeaders?: IHeader[]): Promise<T> {
  const headers = getHeaders(additionalHeaders);
  const options: RequestInit = {
    headers,
    method,
    body: body ? JSON.stringify(body) : undefined
  };

  log.info(`Sending ${method} request to ${url}`);

  return fetch(url, options)
    .then(response => {
      if (response.ok) {
        return response.json() as Promise<T>;
      }
      log.error(`Error ${response.status} (${response.statusText}) while sending ${method} request to ${url} 
              with options ${JSON.stringify(options)}`);
      log.error(response.text());
      return undefined as unknown as Promise<T>;
    });
}

export const http = {
  get: <T>(url: string, additionalHeaders?: IHeader[]): Promise<T> =>
    request<T>(url, 'GET', undefined, additionalHeaders),
  post: <T>(url: string, body: any, additionalHeaders?: IHeader[]): Promise<T> =>
    request<T>(url, 'POST', body, additionalHeaders),
  put: <T>(url: string, body: any, additionalHeaders?: IHeader[]): Promise<T> =>
    request<T>(url, 'PUT', body, additionalHeaders),
  delete: <T>(url: string, additionalHeaders?: IHeader[]): Promise<T> =>
    request<T>(url, 'DELETE', undefined, additionalHeaders)
};

export default http;