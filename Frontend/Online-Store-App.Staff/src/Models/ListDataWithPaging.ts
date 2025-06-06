import type { BaseEntity } from "./Data/Base/BaseEntity";

export interface ListDataWithPaging {
  totalCount: number;
  totalPages: number;
  pageNumber: number;
  pageSize: number;
  items: BaseEntity[];
}
