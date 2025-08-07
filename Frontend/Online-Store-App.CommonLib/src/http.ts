import axios from "axios";
import { webAPIUrl } from "./AppSettings";
import authHeader from "./Services/AuthHeader";

export interface HttpRequest<REQB> {
  path: string;
  method?: string;
  body?: REQB;
  accessToken?: string;
}
export interface HttpResponse<RESB> {
  ok: boolean;
  body?: RESB;
}

export const http = async <RESB, REQB = undefined>(
  config: HttpRequest<REQB>,
  formData: FormData | undefined = undefined
): Promise<HttpResponse<RESB>> => {
  const request = new Request(`${webAPIUrl}/${config.path}`, {
    method: config.method || "get",
    headers: formData ? { } : {
      "Content-Type": "application/json",
    },
    body: formData ? formData : (config.body ? JSON.stringify(config.body) : undefined),
  });

  const accessToken = authHeader();
  if (accessToken) {
    request.headers.set("Authorization", `${accessToken}`);
  }

  const response = await fetch(request);

  if (response.ok) {
    const body = await response.json();
    return { ok: response.ok, body };
  } else {
    return { ok: response.ok };
  }
};

