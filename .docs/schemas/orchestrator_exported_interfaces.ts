export interface PackageName {
    "10words": string;
    description: string;
    valueProp: string;
    highLevelSteps: HighLevelStep[];
    nodes: Node[];
    packageData: PackageData;
    conditions: Condition[];
    integrations: string[];
}

export interface Condition {
    name: string;
    optMode?: string;
    category?: string;
    variables_form?: string;
    tags?: string;
    option_button?: string;
    option_text?: string;
    option_category?: string;
    beta_mode?: string;
    ticket_class?: string;
    ticket_class_threshold_suggest?: string;
}

export interface HighLevelStep {
    title: string;
    detail: string;
    startNodeId: string;
    endNodeId: string;
}

export interface Node {
    id: string;
    type: NodeType;
    data: Data;
    position: Position;
}

export interface Data {
    label: string;
    step: Step;
    details?: Details;
    analysis?: Analysis;
    description?: string;
}

export interface Analysis {
    summary?: string;
    fiveWordSummary?: string;
    countOfActiveLinesOfCode: number;
    integrations: string[];
    codeReview: string[];
    staticName: string;
}

export interface Details {
    id: number;
    createdDate: Date;
    modifiedDate: Date;
    createdByUserId: number;
    modifiedByUserId: number;
    activityStaticName?: string;
    activityName?: string;
    description: null | string;
    imageBlobId?: null;
    imageDownloadUrl?: null;
    imageName?: null;
    powershellCode?: string;
    safeImmutable?: boolean;
    isPublished: boolean;
    isLatestVersion: boolean;
    version: number;
    isDeleted: boolean;
    saveToken: string;
    tags: TagElement[];
    variables?: Variable[];
    sandboxId: number;
    isLocked: boolean;
    type?: DetailsType;
    staticName?: string;
    displayGoButton?: boolean;
    isReadOnly?: boolean;
    displayName?: string;
    formJson?: string;
}

export interface TagElement {
    id: number;
    tagType: number;
    tag: TagEnum;
    cwKey: null;
    color: Color;
    created: Date;
    createdByUserId: number;
    updated: Date;
    updatedByUserId: number;
    isDeleted: boolean;
}

export enum Color {
    The0000Ff = "#0000ff",
}

export enum TagEnum {
    Draft = "Draft",
}

export enum DetailsType {
    Custom = "custom",
}

export interface Variable {
    id: number;
    activityId: number;
    isOutputVariable: boolean;
    name: string;
    isRequired: boolean;
    description: null | string;
    defaultValue: null | string;
    testValue: null;
    optionText: null | string;
}

export interface Step {
    [x: string]: any;
    task: string;
    inputs?: { [key: string]: string };
    alias?: string;
    skip?: string;
    document?: string;
}

export interface Position {
    x: number;
    y: number;
    width?: number;
}

export enum NodeType {
    Activity = "activity",
    Chat = "chat",
    Form = "form",
    InlinePowershell = "inline_powershell",
}

export interface PackageData {
    id: number;
    internalId: string;
    createdDate: Date;
    modifiedDate: Date;
    createdByUserId: number;
    modifiedByUserId: number;
    packageName: string;
    description: string;
    yamlCode: string;
    isDeleted: boolean;
    isPublished: boolean;
    isLatestVersion: boolean;
    version: number;
    isLocked: boolean;
    saveToken: string;
    tags: TagElement[];
    variables: any[];
    sandboxId: number;
    definitionVersion: number;
}
