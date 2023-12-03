export interface Feature{
    carFeatureId : string;
    featureName : string;
    description : string;
    isSelected:boolean
}

export class FeatureDto {
    featureName : string;
    description : string;
}