
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { CreateOrUpdateDocumentInput,DocumentEditDto, DocumentServiceProxy } from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'create-or-edit-document',
  templateUrl: './create-or-edit-document.component.html',
  styleUrls:[
	'create-or-edit-document.component.less'
  ],
})

export class CreateOrEditDocumentComponent
  extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

	  entity: DocumentEditDto=new DocumentEditDto();

    /**
    * 初始化的构造函数
    */
    constructor(
		injector: Injector,
		private _documentService: DocumentServiceProxy
	) {
		super(injector);
    }

    ngOnInit() :void{
		this.init();
    }


    /**
    * 初始化方法
    */
    init(): void {
		this._documentService.getForEdit(this.id).subscribe(result => {
			this.entity = result.document;
		});
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
		const input = new CreateOrUpdateDocumentInput();
		input.document = this.entity;

		this.saving = true;

		this._documentService.createOrUpdate(input)
		.finally(() => (this.saving = false))
		.subscribe(() => {
			this.notify.success(this.l('SavedSuccessfully'));
			this.success(true);
		});
    }
}
