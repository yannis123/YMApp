
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { CreateOrUpdateProductFieldInput,ProductFieldEditDto, ProductFieldServiceProxy } from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'create-or-edit-product-field',
  templateUrl: './create-or-edit-product-field.component.html',
  styleUrls:[
	'create-or-edit-product-field.component.less'
  ],
})

export class CreateOrEditProductFieldComponent
  extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

	  entity: ProductFieldEditDto=new ProductFieldEditDto();

    /**
    * 初始化的构造函数
    */
    constructor(
		injector: Injector,
		private _productFieldService: ProductFieldServiceProxy
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
		this._productFieldService.getForEdit(this.id).subscribe(result => {
			this.entity = result.productField;
		});
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
		const input = new CreateOrUpdateProductFieldInput();
		input.productField = this.entity;

		this.saving = true;

		this._productFieldService.createOrUpdate(input)
		.finally(() => (this.saving = false))
		.subscribe(() => {
			this.notify.success(this.l('SavedSuccessfully'));
			this.success(true);
		});
    }
}
