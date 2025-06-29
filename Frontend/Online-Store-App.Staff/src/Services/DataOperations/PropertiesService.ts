import { http } from "../../http";
import type { ProductPropValue, PropertyValueForPost, PropertyValueForPut } from "../../Models/Data/ProductPropValue";
import type { Property, PropertyForPost, PropertyForPut } from "../../Models/Data/Property";
import type { PropertyView } from "../../Models/ViewModels/PropertyView";

export const getPropertyById = async (
    propertyId: number
): Promise<Property | null> => {
    const result = await http<Property>({
        path: `properties/${propertyId}`
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return null;
    }
}

export const getProperties = async (params: URLSearchParams): Promise<Property[] | undefined> => {
    const result = await http<Property[]>({
        path: `properties?${params.toString()}`
    });
    if (result.ok || result.body) {
        return result.body;
    } else {
        return undefined;
    }
}

export const postProperty = async (
    property: PropertyForPost
): Promise<number | undefined> => {
    const result = await http<number, PropertyForPost>({
        path: "properties",
        method: "post",
        body: property
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return undefined;
    }
}

export const putProperty = async (
    property: PropertyForPut
): Promise<boolean | undefined> => {
    const result = await http<boolean, PropertyForPut>({
        path: "properties",
        method: "put",
        body: property
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return false;
    }
}

export const deleteProperty = async (
    propertyId: number
): Promise<number | undefined> => {
    const result = await http<number>({
        path: `properties/${propertyId}`,
        method: "delete"
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return undefined;
    }
}

export const getPropertyValueById = async (
    valueId: number
): Promise<ProductPropValue | null> => {
    const result = await http<ProductPropValue>({
        path: `properties/values${valueId}`
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return null;
    }
}

export const getPropertyValues = async (params: URLSearchParams): Promise<ProductPropValue[] | undefined> => {
    const result = await http<ProductPropValue[]>({
        path: `properties/values?${params.toString()}`
    });
    if (result.ok || result.body) {
        return result.body;
    } else {
        return undefined;
    }
}

export const postPropertyValue = async (
    property: PropertyValueForPost
): Promise<number | undefined> => {
    const result = await http<number, PropertyValueForPost>({
        path: "properties/values",
        method: "post",
        body: property
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return undefined;
    }
}

export const putPropertyValue = async (
    property: PropertyValueForPut
): Promise<boolean | undefined> => {
    const result = await http<boolean, PropertyValueForPut>({
        path: "properties/values",
        method: "put",
        body: property
    });
    if (result.ok && result.body) {
        return result.body;
    }
    else {
        return false;
    }
}

export const deletePropertyValue = async (
    propertyValueId: number
): Promise<number | undefined> => {
    const result = await http<number>({
        path: `properties/values/${propertyValueId}`,
        method: "delete"
    });
    if (result.ok && result.body){
        return result.body;
    } else {
        return undefined;
    }
}

export const getPropertiesViewByProductId = async(
    productId: number
): Promise<PropertyView[] | undefined> => {
    const result = await http<PropertyView[]>({
        path: `properties/view?productId=${productId}`
    });
    if (result.ok || result.body) {
        return result.body;
    } else {
        return undefined;
    }
}